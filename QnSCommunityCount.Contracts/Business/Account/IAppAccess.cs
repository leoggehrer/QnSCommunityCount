//@QnSCodeCopy
//MdStart
using QnSCommunityCount.Contracts.Persistence.Account;

namespace QnSCommunityCount.Contracts.Business.Account
{
    public partial interface IAppAccess : IOneToMany<IIdentity, IRole>, ICopyable<IAppAccess>
    {

    }
}
//MdEnd
