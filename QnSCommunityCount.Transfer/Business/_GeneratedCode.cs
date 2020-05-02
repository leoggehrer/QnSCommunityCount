namespace QnSCommunityCount.Transfer.Business.App
{
	using System.Text.Json.Serialization;
	public partial class CommunityCosts : QnSCommunityCount.Contracts.Business.App.ICommunityCosts
	{
		static CommunityCosts()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public CommunityCosts()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		[JsonIgnore]
		public QnSCommunityCount.Contracts.Persistence.App.ICostCollection CostCollection
		{
			get
			{
				OnCostCollectionReading();
				return _costCollection;
			}
			set
			{
				bool handled = false;
				OnCostCollectionChanging(ref handled, ref _costCollection);
				if (handled == false)
				{
					this._costCollection = value;
				}
				OnCostCollectionChanged();
			}
		}
		private QnSCommunityCount.Contracts.Persistence.App.ICostCollection _costCollection;
		partial void OnCostCollectionReading();
		partial void OnCostCollectionChanging(ref bool handled, ref QnSCommunityCount.Contracts.Persistence.App.ICostCollection _costCollection);
		partial void OnCostCollectionChanged();
		[JsonIgnore]
		public System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Persistence.App.ICostRecord> CostRecords
		{
			get
			{
				OnCostRecordsReading();
				return _costRecords;
			}
			set
			{
				bool handled = false;
				OnCostRecordsChanging(ref handled, ref _costRecords);
				if (handled == false)
				{
					this._costRecords = value;
				}
				OnCostRecordsChanged();
			}
		}
		private System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Persistence.App.ICostRecord> _costRecords;
		partial void OnCostRecordsReading();
		partial void OnCostRecordsChanging(ref bool handled, ref System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Persistence.App.ICostRecord> _costRecords);
		partial void OnCostRecordsChanged();
		public System.Double TotalCosts
		{
			get
			{
				OnTotalCostsReading();
				return _totalCosts;
			}
			set
			{
				bool handled = false;
				OnTotalCostsChanging(ref handled, ref _totalCosts);
				if (handled == false)
				{
					this._totalCosts = value;
				}
				OnTotalCostsChanged();
			}
		}
		private System.Double _totalCosts;
		partial void OnTotalCostsReading();
		partial void OnTotalCostsChanging(ref bool handled, ref System.Double _totalCosts);
		partial void OnTotalCostsChanged();
		public System.Double CostsPerMember
		{
			get
			{
				OnCostsPerMemberReading();
				return _costsPerMember;
			}
			set
			{
				bool handled = false;
				OnCostsPerMemberChanging(ref handled, ref _costsPerMember);
				if (handled == false)
				{
					this._costsPerMember = value;
				}
				OnCostsPerMemberChanged();
			}
		}
		private System.Double _costsPerMember;
		partial void OnCostsPerMemberReading();
		partial void OnCostsPerMemberChanging(ref bool handled, ref System.Double _costsPerMember);
		partial void OnCostsPerMemberChanged();
		public System.Int32 NumberOfMembers
		{
			get
			{
				OnNumberOfMembersReading();
				return _numberOfMembers;
			}
			set
			{
				bool handled = false;
				OnNumberOfMembersChanging(ref handled, ref _numberOfMembers);
				if (handled == false)
				{
					this._numberOfMembers = value;
				}
				OnNumberOfMembersChanged();
			}
		}
		private System.Int32 _numberOfMembers;
		partial void OnNumberOfMembersReading();
		partial void OnNumberOfMembersChanging(ref bool handled, ref System.Int32 _numberOfMembers);
		partial void OnNumberOfMembersChanged();
		public System.String[] Members
		{
			get
			{
				OnMembersReading();
				return _members;
			}
			set
			{
				bool handled = false;
				OnMembersChanging(ref handled, ref _members);
				if (handled == false)
				{
					this._members = value;
				}
				OnMembersChanged();
			}
		}
		private System.String[] _members;
		partial void OnMembersReading();
		partial void OnMembersChanging(ref bool handled, ref System.String[] _members);
		partial void OnMembersChanged();
		public System.Double[] MemberAmounts
		{
			get
			{
				OnMemberAmountsReading();
				return _memberAmounts;
			}
			set
			{
				bool handled = false;
				OnMemberAmountsChanging(ref handled, ref _memberAmounts);
				if (handled == false)
				{
					this._memberAmounts = value;
				}
				OnMemberAmountsChanged();
			}
		}
		private System.Double[] _memberAmounts;
		partial void OnMemberAmountsReading();
		partial void OnMemberAmountsChanging(ref bool handled, ref System.Double[] _memberAmounts);
		partial void OnMemberAmountsChanged();
		[JsonIgnore]
		public System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Modules.App.IBalance> Balances
		{
			get
			{
				OnBalancesReading();
				return _balances;
			}
			set
			{
				bool handled = false;
				OnBalancesChanging(ref handled, ref _balances);
				if (handled == false)
				{
					this._balances = value;
				}
				OnBalancesChanged();
			}
		}
		private System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Modules.App.IBalance> _balances;
		partial void OnBalancesReading();
		partial void OnBalancesChanging(ref bool handled, ref System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Modules.App.IBalance> _balances);
		partial void OnBalancesChanged();
		public void CopyProperties(QnSCommunityCount.Contracts.Business.App.ICommunityCosts other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				RowVersion = other.RowVersion;
				CostCollection = other.CostCollection;
				CostRecords = other.CostRecords;
				TotalCosts = other.TotalCosts;
				CostsPerMember = other.CostsPerMember;
				NumberOfMembers = other.NumberOfMembers;
				Members = other.Members;
				MemberAmounts = other.MemberAmounts;
				Balances = other.Balances;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSCommunityCount.Contracts.Business.App.ICommunityCosts other, ref bool handled);
		partial void AfterCopyProperties(QnSCommunityCount.Contracts.Business.App.ICommunityCosts other);
	}
}
namespace QnSCommunityCount.Transfer.Business.App
{
	partial class CommunityCosts : IdentityModel
	{
	}
}
namespace QnSCommunityCount.Transfer.Business.Account
{
	using System.Text.Json.Serialization;
	public partial class AppAccess : QnSCommunityCount.Contracts.Business.Account.IAppAccess
	{
		static AppAccess()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public AppAccess()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public void CopyProperties(QnSCommunityCount.Contracts.Business.Account.IAppAccess other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				RowVersion = other.RowVersion;
				FirstItem.CopyProperties(other.FirstItem);
				ClearSecondItems();
				foreach (var item in other.SecondItems)
				{
					AddSecondItem(item);
				}
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSCommunityCount.Contracts.Business.Account.IAppAccess other, ref bool handled);
		partial void AfterCopyProperties(QnSCommunityCount.Contracts.Business.Account.IAppAccess other);
	}
}
namespace QnSCommunityCount.Transfer.Business.Account
{
	partial class AppAccess : OneToManyModel<QnSCommunityCount.Contracts.Persistence.Account.IIdentity, QnSCommunityCount.Transfer.Persistence.Account.Identity, QnSCommunityCount.Contracts.Persistence.Account.IRole, QnSCommunityCount.Transfer.Persistence.Account.Role>
	{
	}
}
namespace QnSCommunityCount.Transfer.Business.Account
{
	using System.Text.Json.Serialization;
	public partial class IdentityUser : QnSCommunityCount.Contracts.Business.Account.IIdentityUser
	{
		static IdentityUser()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public IdentityUser()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public void CopyProperties(QnSCommunityCount.Contracts.Business.Account.IIdentityUser other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				Id = other.Id;
				RowVersion = other.RowVersion;
				FirstItem.CopyProperties(other.FirstItem);
				SecondItem.CopyProperties(other.SecondItem);
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSCommunityCount.Contracts.Business.Account.IIdentityUser other, ref bool handled);
		partial void AfterCopyProperties(QnSCommunityCount.Contracts.Business.Account.IIdentityUser other);
	}
}
namespace QnSCommunityCount.Transfer.Business.Account
{
	partial class IdentityUser : OneToOneModel<QnSCommunityCount.Contracts.Persistence.Account.IIdentity, QnSCommunityCount.Transfer.Persistence.Account.Identity, QnSCommunityCount.Contracts.Persistence.Account.IUser, QnSCommunityCount.Transfer.Persistence.Account.User>
	{
	}
}
