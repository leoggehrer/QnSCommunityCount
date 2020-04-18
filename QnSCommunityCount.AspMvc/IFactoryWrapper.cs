//@QnSCodeCopy
//MdStart
using QnSCommunityCount.Contracts;
using QnSCommunityCount.Contracts.Client;

namespace QnSCommunityCount.AspMvc
{
    public interface IFactoryWrapper
    {
        IAdapterAccess<I> Create<I>() where I : IIdentifiable;
        IAdapterAccess<I> Create<I>(string sessionToken) where I : IIdentifiable;
    }
}
//MdEnd
