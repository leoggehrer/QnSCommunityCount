using System;
using System.Linq;
using System.Collections.Generic;
using CommonBase.Extensions;
using QnSCommunityCount.Logic.Entities.Persistence.App;
using QnSCommunityCount.Logic.Entities.Modules.App;
using QnSCommunityCount.Contracts.Modules.App;
using QnSCommunityCount.Contracts.Persistence.App;
using QnSCommunityCount.Contracts.Business.App;

namespace QnSCommunityCount.Logic.Entities.Business.App
{
    partial class CommunityCosts
    {
        public static string Separator => ",";
        internal CostCollection CostCollectionEntity { get; } = new CostCollection();
        internal List<CostRecord> CostRecordEntities { get; } = new List<CostRecord>();
        public override int Id { get => CostCollectionEntity.Id; set => CostCollectionEntity.Id = value; }
        public override byte[] RowVersion { get => CostCollectionEntity.RowVersion; set => CostCollectionEntity.RowVersion = value; }
        partial void OnCostCollectionReading()
        {
            _costCollection = CostCollectionEntity;
        }
        partial void OnCostRecordsReading()
        {
            _costRecords = CostRecordEntities.Select(i =>
            {
                var cr = new CostRecord();

                cr.CopyProperties(i);
                return cr;
            });
        }
        partial void OnTotalCostsReading()
        {
            _totalCosts = CostRecordEntities.Sum(i => i.Amount);
        }
        partial void OnNumberOfMembersReading()
        {
            _numberOfMembers = Members != null ? Members.Length : 0;
        }
        partial void OnMembersReading()
        {
            _members = CostCollectionEntity.Members != null ? CostCollectionEntity.Members.Split(Separator) : new string[0];
        }
        partial void OnCostsPerMemberReading()
        {
            _costsPerMember = NumberOfMembers != 0 ? TotalCosts / NumberOfMembers : 0;
        }
        partial void OnMemberAmountsReading()
        {
            _memberAmounts = Members.Select(m => CostRecordEntities.Where(r => r.Member.Equals(m)).Sum(j => j.Amount)).ToArray();
        }
        partial void OnBalancesReading()
        {
            _balances = CreateBalances();
        }

        private IEnumerable<IBalance> CreateBalances()
        {
            List<Balance> result = new List<Balance>();
            var costsPerMember = CostsPerMember;
            var memberAmounts = MemberAmounts;
            var memberAndAmounts = Members.Select((m, i) => new { Friend = m, Amount = memberAmounts[i] });
            var gives = memberAndAmounts.Where(i => i.Amount < costsPerMember);
            var gets = memberAndAmounts.Where(i => i.Amount > costsPerMember);

            foreach (var give in gives)
            {
                double giveDif = costsPerMember - give.Amount;

                if (Math.Abs(giveDif) > 0.001)
                {
                    foreach (var get in gets)
                    {
                        var dif = get.Amount - costsPerMember - result.Where(i => i.To.Equals(get.Friend)).Sum(i => i.Amount);

                        if (giveDif > 0.01 && dif > 0.01)
                        {
                            var minDif = Math.Min(dif, giveDif);

                            result.Add(new Balance { From = give.Friend, To = get.Friend, Amount = minDif });
                            giveDif = giveDif - minDif;
                        }
                    }
                }
            }
            return result;
        }

        public ICostRecord CreateCostRecord()
        {
            return new CostRecord() { Date = DateTime.Now };
        }
        public void AddCostRecord(ICostRecord costRecord)
        {
            costRecord.CheckArgument(nameof(costRecord));

            var entity = new CostRecord();

            entity.CopyProperties(costRecord);
            CostRecordEntities.Add(entity);
        }
        public void UpdateCostRecord(ICostRecord costRecord)
        {
            costRecord.CheckArgument(nameof(costRecord));

            var entity = CostRecordEntities.FirstOrDefault(i => (i.Id != 0 && i.Id == costRecord.Id));
            if (entity != null)
            {
                entity.CopyProperties(costRecord);
            }
        }
        public void RemoveCostRecord(ICostRecord costRecord)
        {
            costRecord.CheckArgument(nameof(costRecord));

            var entity = CostRecordEntities.FirstOrDefault(i => (i.Id != 0 && i.Id == costRecord.Id)
                                                             || (i.Id == 0 && i.Designation != null && i.Designation.Equals(costRecord.Designation)));
            if (entity != null)
            {
                CostRecordEntities.Remove(entity);
            }
        }

        partial void BeforeCopyProperties(ICommunityCosts other, ref bool handled)
        {
            other.CheckArgument(nameof(other));
            other.CostCollection.CheckArgument(nameof(other.CostCollection));
            other.CostRecords.CheckArgument(nameof(other.CostRecords));

            handled = true;
            CostCollectionEntity.CopyProperties(other.CostCollection);
            CostRecordEntities.Clear();
            foreach (var item in other.CostRecords)
            {
                var costRecord = new CostRecord();

                costRecord.CopyProperties(item);
                CostRecordEntities.Add(costRecord);
            }
        }
    }
}
