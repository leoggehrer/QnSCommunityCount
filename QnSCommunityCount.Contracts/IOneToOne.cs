//@QnSCodeCopy
//MdStart

namespace QnSCommunityCount.Contracts
{
    public partial interface IOneToOne<TFirst, TSecond> : IIdentifiable
        where TFirst : IIdentifiable
        where TSecond : IIdentifiable
    {
        TFirst FirstItem { get; }
        TSecond SecondItem { get; }
    }
}
//MdEnd
