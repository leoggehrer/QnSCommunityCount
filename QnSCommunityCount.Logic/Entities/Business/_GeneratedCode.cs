namespace QnSCommunityCount.Logic.Entities.Business.App
{
	using System;
	partial class CommunityCosts : QnSCommunityCount.Contracts.Business.App.ICommunityCosts
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
				Timestamp = other.Timestamp;
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
		public override bool Equals(object obj)
		{
			if (!(obj is QnSCommunityCount.Contracts.Business.App.ICommunityCosts instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSCommunityCount.Contracts.Business.App.ICommunityCosts other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(CostCollection, other.CostCollection) && IsEqualsWith(CostRecords, other.CostRecords) && TotalCosts == other.TotalCosts && CostsPerMember == other.CostsPerMember && NumberOfMembers == other.NumberOfMembers && IsEqualsWith(Members, other.Members) && IsEqualsWith(MemberAmounts, other.MemberAmounts) && IsEqualsWith(Balances, other.Balances);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, CostCollection, CostRecords, TotalCosts, CostsPerMember, HashCode.Combine(NumberOfMembers, Members, MemberAmounts, Balances));
		}
	}
}
namespace QnSCommunityCount.Logic.Entities.Business.App
{
	partial class CommunityCosts : IdentityObject
	{
	}
}
namespace QnSCommunityCount.Logic.Entities.Business.Account
{
	using System;
	partial class AppAccess : QnSCommunityCount.Contracts.Business.Account.IAppAccess
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
		public QnSCommunityCount.Contracts.Persistence.Account.IIdentity Identity
		{
			get
			{
				OnIdentityReading();
				return _identity;
			}
			set
			{
				bool handled = false;
				OnIdentityChanging(ref handled, ref _identity);
				if (handled == false)
				{
					this._identity = value;
				}
				OnIdentityChanged();
			}
		}
		private QnSCommunityCount.Contracts.Persistence.Account.IIdentity _identity;
		partial void OnIdentityReading();
		partial void OnIdentityChanging(ref bool handled, ref QnSCommunityCount.Contracts.Persistence.Account.IIdentity _identity);
		partial void OnIdentityChanged();
		public System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Persistence.Account.IRole> Roles
		{
			get
			{
				OnRolesReading();
				return _roles;
			}
			set
			{
				bool handled = false;
				OnRolesChanging(ref handled, ref _roles);
				if (handled == false)
				{
					this._roles = value;
				}
				OnRolesChanged();
			}
		}
		private System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Persistence.Account.IRole> _roles;
		partial void OnRolesReading();
		partial void OnRolesChanging(ref bool handled, ref System.Collections.Generic.IEnumerable<QnSCommunityCount.Contracts.Persistence.Account.IRole> _roles);
		partial void OnRolesChanged();
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
				Timestamp = other.Timestamp;
				Identity = other.Identity;
				Roles = other.Roles;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSCommunityCount.Contracts.Business.Account.IAppAccess other, ref bool handled);
		partial void AfterCopyProperties(QnSCommunityCount.Contracts.Business.Account.IAppAccess other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSCommunityCount.Contracts.Business.Account.IAppAccess instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSCommunityCount.Contracts.Business.Account.IAppAccess other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(Timestamp, other.Timestamp) && IsEqualsWith(Identity, other.Identity) && IsEqualsWith(Roles, other.Roles);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Timestamp, Identity, Roles);
		}
	}
}
namespace QnSCommunityCount.Logic.Entities.Business.Account
{
	partial class AppAccess : IdentityObject
	{
	}
}
