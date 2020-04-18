//@DomainCode
//MdStart
using System;

namespace QnSCommunityCount.Contracts.Persistence.App
{
    public interface ICostRecord : IIdentifiable, ICopyable<ICostRecord>
    {
        int CostCollectionId { get; set; }
        DateTime Date { get; }
        string Designation { get; set; }
        double Amount { get; set; }
        string Member { get; set; }
    }
}
//MdEnd
