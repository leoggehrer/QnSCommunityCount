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
	sealed partial class AppAccessController : GenericOneToManyController<QnSCommunityCount.Contracts.Business.Account.IAppAccess, Entities.Business.Account.AppAccess, QnSCommunityCount.Contracts.Persistence.Account.IIdentity, QnSCommunityCount.Logic.Entities.Persistence.Account.Identity, QnSCommunityCount.Contracts.Persistence.Account.IRole, QnSCommunityCount.Logic.Entities.Persistence.Account.Role>
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
		protected override GenericController<QnSCommunityCount.Contracts.Persistence.Account.IIdentity, QnSCommunityCount.Logic.Entities.Persistence.Account.Identity> CreateFirstEntityController(ControllerObject controller)
		{
			return new QnSCommunityCount.Logic.Controllers.Persistence.Account.IdentityController(controller);
		}
		protected override GenericController<QnSCommunityCount.Contracts.Persistence.Account.IRole, QnSCommunityCount.Logic.Entities.Persistence.Account.Role> CreateSecondEntityController(ControllerObject controller)
		{
			return new QnSCommunityCount.Logic.Controllers.Persistence.Account.RoleController(controller);
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Business.Account
{
	sealed partial class IdentityUserController : GenericOneToOneController<QnSCommunityCount.Contracts.Business.Account.IIdentityUser, Entities.Business.Account.IdentityUser, QnSCommunityCount.Contracts.Persistence.Account.IIdentity, QnSCommunityCount.Logic.Entities.Persistence.Account.Identity, QnSCommunityCount.Contracts.Persistence.Account.IUser, QnSCommunityCount.Logic.Entities.Persistence.Account.User>
	{
		static IdentityUserController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public IdentityUserController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public IdentityUserController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
		protected override GenericController<QnSCommunityCount.Contracts.Persistence.Account.IIdentity, QnSCommunityCount.Logic.Entities.Persistence.Account.Identity> CreateFirstEntityController(ControllerObject controller)
		{
			return new QnSCommunityCount.Logic.Controllers.Persistence.Account.IdentityController(controller);
		}
		protected override GenericController<QnSCommunityCount.Contracts.Persistence.Account.IUser, QnSCommunityCount.Logic.Entities.Persistence.Account.User> CreateSecondEntityController(ControllerObject controller)
		{
			return new QnSCommunityCount.Logic.Controllers.Persistence.Account.UserController(controller);
		}
	}
}
