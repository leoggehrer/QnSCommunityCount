﻿using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using CommonBase.Extensions;
using QnSCommunityCount.Contracts.Business.App;
using QnSCommunityCount.Contracts.Persistence.App;
using QnSCommunityCount.Transfer.Modules.App;
using QnSCommunityCount.Transfer.Persistence.App;

namespace QnSCommunityCount.Transfer.Business.App
{
    partial class CommunityCosts
    {
        public static string Separator => ",";

        [JsonPropertyName(nameof(CostCollection))]
        public CostCollection CostCollectionEntity { get; } = new CostCollection();
        [JsonPropertyName(nameof(CostRecords))]
        public List<CostRecord> CostRecordEntities { get; } = new List<CostRecord>();
        [JsonPropertyName(nameof(Balances))]
        public List<Balance> BalanceEntities { get; set; } = new List<Balance>();

        public override int Id { get => CostCollection.Id; }
        public override byte[] RowVersion { get => CostCollection.RowVersion; }
        partial void OnCostCollectionReading()
        {
            _costCollection = CostCollectionEntity;
        }
        partial void OnCostRecordsReading()
        {
            _costRecords = CostRecordEntities.Select( i =>
            {
                var cr = new CostRecord();

                cr.CopyProperties(i);
                return cr;
            });
        }
        partial void OnBalancesReading()
        {
            _balances = BalanceEntities;
        }

        public ICostRecord CreateCostRecord()
        {
            return new CostRecord();
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
            other.Balances.CheckArgument(nameof(other.Balances));

            handled = true;
            TotalCosts = other.TotalCosts;
            CostsPerMember = other.CostsPerMember;
            NumberOfMembers = other.NumberOfMembers;
            Members = other.Members;
            MemberAmounts = other.MemberAmounts;
            CostCollectionEntity.CopyProperties(other.CostCollection);
            CostRecordEntities.Clear();
            foreach (var item in other.CostRecords)
            {
                var costRecord = new CostRecord();

                costRecord.CopyProperties(item);
                CostRecordEntities.Add(costRecord);
            }
            BalanceEntities.Clear();
            foreach (var item in other.Balances)
            {
                var balance = new Balance();

                balance.CopyProperties(item);
                BalanceEntities.Add(balance);
            }
        }
    }
}
