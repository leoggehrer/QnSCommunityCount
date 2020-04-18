//MdStart
using QnSCommunityCount.Logic.DataContext;

namespace QnSCommunityCount.Logic.Controllers.Persistence
{
    internal abstract partial class QnSCommunityCountController<I, E> : GenericController<I, E>
       where I : Contracts.IIdentifiable
       where E : Entities.IdentityObject, I, Contracts.ICopyable<I>, new()
    {
        internal IQnSCommunityCountContext QnSCommunityCountContext => (IQnSCommunityCountContext)Context;

        protected QnSCommunityCountController(IContext context)
            : base(context)
        {
        }
        protected QnSCommunityCountController(ControllerObject controller)
            : base(controller)
        {
        }
    }
}
//MdEnd
