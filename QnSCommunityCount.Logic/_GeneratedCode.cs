namespace QnSCommunityCount.Logic
{
	public static partial class Factory
	{
		public static Contracts.Client.IControllerAccess<I> Create<I>() where I : Contracts.IIdentifiable
		{
			Contracts.Client.IControllerAccess<I> result = null;
			if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
			{
				result = new Controllers.Persistence.App.CostCollectionController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
			{
				result = new Controllers.Persistence.App.CostRecordController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
			{
				result = new Controllers.Persistence.Account.RoleController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IUser))
			{
				result = new Controllers.Persistence.Account.UserController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
			{
				result = new Controllers.Business.App.CommunityCostsController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
			{
				result = new Controllers.Business.Account.AppAccessController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IIdentityUser))
			{
				result = new Controllers.Business.Account.IdentityUserController(CreateContext()) as Contracts.Client.IControllerAccess<I>;
			}
			return result;
		}
		public static Contracts.Client.IControllerAccess<I> Create<I>(object sharedController) where I : Contracts.IIdentifiable
		{
			Contracts.Client.IControllerAccess<I> result = null;
			if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
			{
				result = new Controllers.Persistence.App.CostCollectionController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
			{
				result = new Controllers.Persistence.App.CostRecordController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
			{
				result = new Controllers.Persistence.Account.RoleController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IUser))
			{
				result = new Controllers.Persistence.Account.UserController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
			{
				result = new Controllers.Business.App.CommunityCostsController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
			{
				result = new Controllers.Business.Account.AppAccessController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IIdentityUser))
			{
				result = new Controllers.Business.Account.IdentityUserController(sharedController as Controllers.ControllerObject) as Contracts.Client.IControllerAccess<I>;
			}
			return result;
		}
		public static Contracts.Client.IControllerAccess<I> Create<I>(string sessionToken) where I : Contracts.IIdentifiable
		{
			Contracts.Client.IControllerAccess<I> result = null;
			if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
			{
				result = new Controllers.Persistence.App.CostCollectionController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
			{
				result = new Controllers.Persistence.App.CostRecordController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
			{
				result = new Controllers.Persistence.Account.RoleController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IUser))
			{
				result = new Controllers.Persistence.Account.UserController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
			{
				result = new Controllers.Business.App.CommunityCostsController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
			{
				result = new Controllers.Business.Account.AppAccessController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IIdentityUser))
			{
				result = new Controllers.Business.Account.IdentityUserController(CreateContext())
				{
					SessionToken = sessionToken
				}
				as Contracts.Client.IControllerAccess<I>;
			}
			return result;
		}
	}
}
