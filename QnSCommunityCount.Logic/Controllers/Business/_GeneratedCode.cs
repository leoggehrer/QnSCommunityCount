namespace QnSCommunityCount.Logic.Controllers.Business.App
{
	sealed partial class CommunityCostsController : BusinessControllerAdapter<QnSCommunityCount.Contracts.Business.App.ICommunityCosts, Entities.Business.App.CommunityCosts>
	{
		static CommunityCostsController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public CommunityCostsController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public CommunityCostsController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Business.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class AppAccessController : BusinessControllerAdapter<QnSCommunityCount.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess>
	{
		static AppAccessController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public AppAccessController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public AppAccessController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
