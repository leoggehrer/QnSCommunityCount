//@DomainCode
//MdStart
using System;

namespace QnSCommunityCount.Contracts.Persistence.App
{
    public interface ICostCollection : IIdentifiable, ICopyable<ICostCollection>
    {
        DateTime Date { get; }
        string Designation { get; set; }
        string Description { get; set; }
        string Currency { get; set; }
        string Members { get; set; }
        string Category { get; set; }
    }
}
//MdEnd
