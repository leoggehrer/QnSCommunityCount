namespace QnSCommunityCount.Logic.DataContext.Db
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;
	partial class QnSCommunityCountDbContext : GenericDbContext
	{
		protected DbSet<Entities.Persistence.App.CostCollection> CostCollectionSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.App.CostRecord> CostRecordSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.ActionLog> ActionLogSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.Identity> IdentitySet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.IdentityXRole> IdentityXRoleSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.LoginSession> LoginSessionSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.Role> RoleSet
		{
			get;
			set;
		}
		protected DbSet<Entities.Persistence.Account.User> UserSet
		{
			get;
			set;
		}
		public override DbSet<E> Set<I, E>()
		{
			DbSet<E> result = null;
			if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostCollection))
			{
				result = CostCollectionSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.App.ICostRecord))
			{
				result = CostRecordSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IActionLog))
			{
				result = ActionLogSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IIdentity))
			{
				result = IdentitySet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IIdentityXRole))
			{
				result = IdentityXRoleSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.ILoginSession))
			{
				result = LoginSessionSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IRole))
			{
				result = RoleSet as DbSet<E>;
			}
			else if (typeof(I) == typeof(QnSCommunityCount.Contracts.Persistence.Account.IUser))
			{
				result = UserSet as DbSet<E>;
			}
			return result;
		}
		partial void DoModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Entities.Persistence.App.CostCollection>().ToTable(nameof(Entities.Persistence.App.CostCollection), nameof(Entities.Persistence.App)).HasKey(nameof(Entities.Persistence.App.CostCollection.Id));
			modelBuilder.Entity<Entities.Persistence.App.CostCollection>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.App.CostCollection>());
			modelBuilder.Entity<Entities.Persistence.App.CostRecord>().ToTable(nameof(Entities.Persistence.App.CostRecord), nameof(Entities.Persistence.App)).HasKey(nameof(Entities.Persistence.App.CostRecord.Id));
			modelBuilder.Entity<Entities.Persistence.App.CostRecord>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.App.CostRecord>());
			modelBuilder.Entity<Entities.Persistence.Account.ActionLog>().ToTable(nameof(Entities.Persistence.Account.ActionLog), nameof(Entities.Persistence.Account)).HasKey(nameof(Entities.Persistence.Account.ActionLog.Id));
			modelBuilder.Entity<Entities.Persistence.Account.ActionLog>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.Account.ActionLog>());
			modelBuilder.Entity<Entities.Persistence.Account.Identity>().ToTable(nameof(Entities.Persistence.Account.Identity), nameof(Entities.Persistence.Account)).HasKey(nameof(Entities.Persistence.Account.Identity.Id));
			modelBuilder.Entity<Entities.Persistence.Account.Identity>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.Account.Identity>());
			modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>().ToTable(nameof(Entities.Persistence.Account.IdentityXRole), nameof(Entities.Persistence.Account)).HasKey(nameof(Entities.Persistence.Account.IdentityXRole.Id));
			modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.Account.IdentityXRole>());
			modelBuilder.Entity<Entities.Persistence.Account.LoginSession>().ToTable(nameof(Entities.Persistence.Account.LoginSession), nameof(Entities.Persistence.Account)).HasKey(nameof(Entities.Persistence.Account.LoginSession.Id));
			modelBuilder.Entity<Entities.Persistence.Account.LoginSession>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.Account.LoginSession>());
			modelBuilder.Entity<Entities.Persistence.Account.Role>().ToTable(nameof(Entities.Persistence.Account.Role), nameof(Entities.Persistence.Account)).HasKey(nameof(Entities.Persistence.Account.Role.Id));
			modelBuilder.Entity<Entities.Persistence.Account.Role>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.Account.Role>());
			modelBuilder.Entity<Entities.Persistence.Account.User>().ToTable(nameof(Entities.Persistence.Account.User), nameof(Entities.Persistence.Account)).HasKey(nameof(Entities.Persistence.Account.User.Id));
			modelBuilder.Entity<Entities.Persistence.Account.User>().Property(p => p.Timestamp).IsRowVersion();
			ConfigureEntityType(modelBuilder.Entity<Entities.Persistence.Account.User>());
		}
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.CostCollection> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.App.CostRecord> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.ActionLog> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Identity> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.IdentityXRole> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.LoginSession> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.Role> entityTypeBuilder);
		partial void ConfigureEntityType(EntityTypeBuilder<Entities.Persistence.Account.User> entityTypeBuilder);
	}
}
