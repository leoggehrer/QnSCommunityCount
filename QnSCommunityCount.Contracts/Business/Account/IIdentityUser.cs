//@QnSCodeCopy
//MdStart
using QnSCommunityCount.Contracts.Persistence.Account;

namespace QnSCommunityCount.Contracts.Business.Account
{
    public partial interface IIdentityUser : IOneToOne<IIdentity, IUser>, ICopyable<IIdentityUser>
    {
    }
}
//MdEnd
