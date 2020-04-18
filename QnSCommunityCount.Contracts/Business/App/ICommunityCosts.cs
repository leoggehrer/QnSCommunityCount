using System.Collections.Generic;
using QnSCommunityCount.Contracts.Modules.App;
using QnSCommunityCount.Contracts.Persistence.App;

namespace QnSCommunityCount.Contracts.Business.App
{
    public interface ICommunityCosts : IIdentifiable, ICopyable<ICommunityCosts>
    {
        ICostCollection CostCollection { get; }
        IEnumerable<ICostRecord> CostRecords { get; }

        double TotalCosts { get; }
        double CostsPerMember { get; }
        int NumberOfMembers { get; }
        string[] Members { get; }
        double[] MemberAmounts { get; }
        ICostRecord CreateCostRecord();
        void AddCostRecord(ICostRecord costRecord);
        void UpdateCostRecord(ICostRecord costRecord);
        void RemoveCostRecord(ICostRecord costRecord);

        IEnumerable<IBalance> Balances { get; }
    }
}
