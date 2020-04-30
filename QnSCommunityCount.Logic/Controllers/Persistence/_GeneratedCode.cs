namespace QnSCommunityCount.Logic.Controllers.Persistence.App
{
	sealed partial class CostCollectionController : GenericController<QnSCommunityCount.Contracts.Persistence.App.ICostCollection, Entities.Persistence.App.CostCollection>
	{
		static CostCollectionController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal CostCollectionController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal CostCollectionController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.App
{
	sealed partial class CostRecordController : GenericController<QnSCommunityCount.Contracts.Persistence.App.ICostRecord, Entities.Persistence.App.CostRecord>
	{
		static CostRecordController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal CostRecordController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal CostRecordController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.Account
{
	sealed partial class ActionLogController : GenericController<QnSCommunityCount.Contracts.Persistence.Account.IActionLog, Entities.Persistence.Account.ActionLog>
	{
		static ActionLogController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal ActionLogController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal ActionLogController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class IdentityController : GenericController<QnSCommunityCount.Contracts.Persistence.Account.IIdentity, Entities.Persistence.Account.Identity>
	{
		static IdentityController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal IdentityController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal IdentityController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class IdentityXRoleController : GenericController<QnSCommunityCount.Contracts.Persistence.Account.IIdentityXRole, Entities.Persistence.Account.IdentityXRole>
	{
		static IdentityXRoleController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal IdentityXRoleController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal IdentityXRoleController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class LoginSessionController : GenericController<QnSCommunityCount.Contracts.Persistence.Account.ILoginSession, Entities.Persistence.Account.LoginSession>
	{
		static LoginSessionController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal LoginSessionController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal LoginSessionController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.Account
{
	[Logic.Modules.Security.Authorize("SysAdmin")]
	sealed partial class RoleController : GenericController<QnSCommunityCount.Contracts.Persistence.Account.IRole, Entities.Persistence.Account.Role>
	{
		static RoleController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal RoleController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal RoleController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
namespace QnSCommunityCount.Logic.Controllers.Persistence.Account
{
	sealed partial class UserController : GenericController<QnSCommunityCount.Contracts.Persistence.Account.IUser, Entities.Persistence.Account.User>
	{
		static UserController()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		internal UserController(DataContext.IContext context):base(context)
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		internal UserController(ControllerObject controller):base(controller)
		{
			Constructing();
			Constructed();
		}
	}
}
