namespace QnSCommunityCount.Logic.Entities.Modules.Language
{
	using System;
	partial class Translation : QnSCommunityCount.Contracts.Modules.Language.ITranslation
	{
		static Translation()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Translation()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.String AppName
		{
			get
			{
				OnAppNameReading();
				return _appName;
			}
			set
			{
				bool handled = false;
				OnAppNameChanging(ref handled, ref _appName);
				if (handled == false)
				{
					this._appName = value;
				}
				OnAppNameChanged();
			}
		}
		private System.String _appName;
		partial void OnAppNameReading();
		partial void OnAppNameChanging(ref bool handled, ref System.String _appName);
		partial void OnAppNameChanged();
		public QnSCommunityCount.Contracts.Modules.Language.LanguageCode KeyLanguage
		{
			get
			{
				OnKeyLanguageReading();
				return _keyLanguage;
			}
			set
			{
				bool handled = false;
				OnKeyLanguageChanging(ref handled, ref _keyLanguage);
				if (handled == false)
				{
					this._keyLanguage = value;
				}
				OnKeyLanguageChanged();
			}
		}
		private QnSCommunityCount.Contracts.Modules.Language.LanguageCode _keyLanguage;
		partial void OnKeyLanguageReading();
		partial void OnKeyLanguageChanging(ref bool handled, ref QnSCommunityCount.Contracts.Modules.Language.LanguageCode _keyLanguage);
		partial void OnKeyLanguageChanged();
		public System.String Key
		{
			get
			{
				OnKeyReading();
				return _key;
			}
			set
			{
				bool handled = false;
				OnKeyChanging(ref handled, ref _key);
				if (handled == false)
				{
					this._key = value;
				}
				OnKeyChanged();
			}
		}
		private System.String _key;
		partial void OnKeyReading();
		partial void OnKeyChanging(ref bool handled, ref System.String _key);
		partial void OnKeyChanged();
		public QnSCommunityCount.Contracts.Modules.Language.LanguageCode ValueLanguage
		{
			get
			{
				OnValueLanguageReading();
				return _valueLanguage;
			}
			set
			{
				bool handled = false;
				OnValueLanguageChanging(ref handled, ref _valueLanguage);
				if (handled == false)
				{
					this._valueLanguage = value;
				}
				OnValueLanguageChanged();
			}
		}
		private QnSCommunityCount.Contracts.Modules.Language.LanguageCode _valueLanguage;
		partial void OnValueLanguageReading();
		partial void OnValueLanguageChanging(ref bool handled, ref QnSCommunityCount.Contracts.Modules.Language.LanguageCode _valueLanguage);
		partial void OnValueLanguageChanged();
		public System.String Value
		{
			get
			{
				OnValueReading();
				return _value;
			}
			set
			{
				bool handled = false;
				OnValueChanging(ref handled, ref _value);
				if (handled == false)
				{
					this._value = value;
				}
				OnValueChanged();
			}
		}
		private System.String _value;
		partial void OnValueReading();
		partial void OnValueChanging(ref bool handled, ref System.String _value);
		partial void OnValueChanged();
		public void CopyProperties(QnSCommunityCount.Contracts.Modules.Language.ITranslation other)
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
				AppName = other.AppName;
				KeyLanguage = other.KeyLanguage;
				Key = other.Key;
				ValueLanguage = other.ValueLanguage;
				Value = other.Value;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSCommunityCount.Contracts.Modules.Language.ITranslation other, ref bool handled);
		partial void AfterCopyProperties(QnSCommunityCount.Contracts.Modules.Language.ITranslation other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSCommunityCount.Contracts.Modules.Language.ITranslation instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSCommunityCount.Contracts.Modules.Language.ITranslation other)
		{
			if (other == null)
			{
				return false;
			}
			return Id == other.Id && IsEqualsWith(RowVersion, other.RowVersion) && IsEqualsWith(AppName, other.AppName) && KeyLanguage == other.KeyLanguage && IsEqualsWith(Key, other.Key) && ValueLanguage == other.ValueLanguage && IsEqualsWith(Value, other.Value);
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(Id, RowVersion, AppName, KeyLanguage, Key, ValueLanguage, HashCode.Combine(Value));
		}
	}
}
namespace QnSCommunityCount.Logic.Entities.Modules.Language
{
	partial class Translation : IdentityObject
	{
	}
}
namespace QnSCommunityCount.Logic.Entities.Modules.App
{
	using System;
	partial class Balance : QnSCommunityCount.Contracts.Modules.App.IBalance
	{
		static Balance()
		{
			ClassConstructing();
			ClassConstructed();
		}
		static partial void ClassConstructing();
		static partial void ClassConstructed();
		public Balance()
		{
			Constructing();
			Constructed();
		}
		partial void Constructing();
		partial void Constructed();
		public System.String From
		{
			get
			{
				OnFromReading();
				return _from;
			}
			set
			{
				bool handled = false;
				OnFromChanging(ref handled, ref _from);
				if (handled == false)
				{
					this._from = value;
				}
				OnFromChanged();
			}
		}
		private System.String _from;
		partial void OnFromReading();
		partial void OnFromChanging(ref bool handled, ref System.String _from);
		partial void OnFromChanged();
		public System.String To
		{
			get
			{
				OnToReading();
				return _to;
			}
			set
			{
				bool handled = false;
				OnToChanging(ref handled, ref _to);
				if (handled == false)
				{
					this._to = value;
				}
				OnToChanged();
			}
		}
		private System.String _to;
		partial void OnToReading();
		partial void OnToChanging(ref bool handled, ref System.String _to);
		partial void OnToChanged();
		public System.Double Amount
		{
			get
			{
				OnAmountReading();
				return _amount;
			}
			set
			{
				bool handled = false;
				OnAmountChanging(ref handled, ref _amount);
				if (handled == false)
				{
					this._amount = value;
				}
				OnAmountChanged();
			}
		}
		private System.Double _amount;
		partial void OnAmountReading();
		partial void OnAmountChanging(ref bool handled, ref System.Double _amount);
		partial void OnAmountChanged();
		public void CopyProperties(QnSCommunityCount.Contracts.Modules.App.IBalance other)
		{
			if (other == null)
			{
				throw new System.ArgumentNullException(nameof(other));
			}
			bool handled = false;
			BeforeCopyProperties(other, ref handled);
			if (handled == false)
			{
				From = other.From;
				To = other.To;
				Amount = other.Amount;
			}
			AfterCopyProperties(other);
		}
		partial void BeforeCopyProperties(QnSCommunityCount.Contracts.Modules.App.IBalance other, ref bool handled);
		partial void AfterCopyProperties(QnSCommunityCount.Contracts.Modules.App.IBalance other);
		public override bool Equals(object obj)
		{
			if (!(obj is QnSCommunityCount.Contracts.Modules.App.IBalance instance))
			{
				return false;
			}
			return base.Equals(instance) && Equals(instance);
		}
		protected bool Equals(QnSCommunityCount.Contracts.Modules.App.IBalance other)
		{
			if (other == null)
			{
				return false;
			}
			return IsEqualsWith(From, other.From) && IsEqualsWith(To, other.To) && Amount == other.Amount;
		}
		public override int GetHashCode()
		{
			return HashCode.Combine(From, To, Amount);
		}
	}
}
namespace QnSCommunityCount.Logic.Entities.Modules.App
{
	partial class Balance : ModuleObject
	{
	}
}
