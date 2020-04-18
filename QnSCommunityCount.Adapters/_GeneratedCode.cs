namespace QnSCommunityCount.Adapters
{
	public static partial class Factory
	{
		public static Contracts.Client.IAdapterAccess<I> Create<I>()
		{
			Contracts.Client.IAdapterAccess<I> result = null;
			if (Adapter == AdapterType.Controller)
			{
				if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostCollection>() as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostRecord>() as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Persistence.Account.IRole>() as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Business.App.ICommunityCosts>() as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Business.Account.IAppAccess>() as Contracts.Client.IAdapterAccess<I>;
				}
			}
			else if (Adapter == AdapterType.Service)
			{
				if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostCollection, Transfer.Persistence.App.CostCollection>(BaseUri, "CostCollection") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostRecord, Transfer.Persistence.App.CostRecord>(BaseUri, "CostRecord") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Persistence.Account.IRole, Transfer.Persistence.Account.Role>(BaseUri, "Role") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Business.App.ICommunityCosts, Transfer.Business.App.CommunityCosts>(BaseUri, "CommunityCosts") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Business.Account.IAppAccess, Transfer.Business.Account.AppAccess>(BaseUri, "AppAccess") as Contracts.Client.IAdapterAccess<I>;
				}
			}
			return result;
		}
		public static Contracts.Client.IAdapterAccess<I> Create<I>(string sessionToken)
		{
			Contracts.Client.IAdapterAccess<I> result = null;
			if (Adapter == AdapterType.Controller)
			{
				if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostCollection>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostRecord>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Persistence.Account.IRole>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Business.App.ICommunityCosts>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
				{
					result = new Controller.GenericControllerAdapter<QnSCommunityCount.Contracts.Business.Account.IAppAccess>(sessionToken) as Contracts.Client.IAdapterAccess<I>;
				}
			}
			else if (Adapter == AdapterType.Service)
			{
				if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostCollection, Transfer.Persistence.App.CostCollection>(sessionToken, BaseUri, "CostCollection") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Persistence.App.ICostRecord, Transfer.Persistence.App.CostRecord>(sessionToken, BaseUri, "CostRecord") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Persistence.Account.IRole, Transfer.Persistence.Account.Role>(sessionToken, BaseUri, "Role") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.App.ICommunityCosts))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Business.App.ICommunityCosts, Transfer.Business.App.CommunityCosts>(sessionToken, BaseUri, "CommunityCosts") as Contracts.Client.IAdapterAccess<I>;
				}
				else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Business.Account.IAppAccess))
				{
					result = new Service.GenericServiceAdapter<QnSCommunityCount.Contracts.Business.Account.IAppAccess, Transfer.Business.Account.AppAccess>(sessionToken, BaseUri, "AppAccess") as Contracts.Client.IAdapterAccess<I>;
				}
			}
			return result;
		}
	}
}
