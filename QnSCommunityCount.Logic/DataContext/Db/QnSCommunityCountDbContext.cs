//@QnSCodeCopy
//MdStart
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using QnSCommunityCount.Logic.Entities.Persistence.Account;

namespace QnSCommunityCount.Logic.DataContext.Db
{
    internal partial class QnSCommunityCountDbContext
    {
        static QnSCommunityCountDbContext()
        {
            ClassConstructing();
            ConnectionString = Modules.Configuration.Settings.Get(CommonBase.StaticLiterals.ConnectionString);
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

#if DEBUG
        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter((category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information)
                .AddDebug();
        });
#endif
        private static string ConnectionString { get; set; }

        public QnSCommunityCountDbContext()
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            BeforeConfiguring(optionsBuilder);
            optionsBuilder
#if DEBUG        
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(loggerFactory)
#endif
                .UseSqlServer(ConnectionString);
            AfterConfiguring(optionsBuilder);
        }
        partial void BeforeConfiguring(DbContextOptionsBuilder optionsBuilder);
        partial void AfterConfiguring(DbContextOptionsBuilder optionsBuilder);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BeforeModelCreating(modelBuilder);
            DoModelCreating(modelBuilder);
            AfterModelCreating(modelBuilder);
#if DEBUG
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
#endif
            base.OnModelCreating(modelBuilder);
        }
        partial void BeforeModelCreating(ModelBuilder modelBuilder);
        partial void DoModelCreating(ModelBuilder modelBuilder);
        partial void AfterModelCreating(ModelBuilder modelBuilder);

        partial void ConfigureEntityType(EntityTypeBuilder<Identity> entityTypeBuilder)
        {
            entityTypeBuilder
                .Ignore(p => p.Password);

            entityTypeBuilder
                .Property(p => p.Guid)
                .IsRequired()
                .HasMaxLength(36);
            entityTypeBuilder
                .HasIndex(p => p.Email)
                .IsUnique();
            entityTypeBuilder
                .Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(128);
            entityTypeBuilder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(128);
            entityTypeBuilder
                .Property(p => p.PasswordHash)
                .IsRequired();
            entityTypeBuilder
                .Property(p => p.PasswordSalt)
                .IsRequired();
        }
        partial void ConfigureEntityType(EntityTypeBuilder<Role> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasIndex(p => p.Designation)
                .IsUnique();
            entityTypeBuilder
                .Property(p => p.Designation)
                .IsRequired()
                .HasMaxLength(64);
            entityTypeBuilder
                .Property(p => p.Description)
                .HasMaxLength(256);
        }
        partial void ConfigureEntityType(EntityTypeBuilder<LoginSession> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(p => p.SessionToken)
                .IsRequired()
                .HasMaxLength(256);

            entityTypeBuilder
                .Ignore(p => p.IsRemoteAuth);
            entityTypeBuilder
                .Ignore(p => p.Origin);
            entityTypeBuilder
                .Ignore(p => p.Name);
            entityTypeBuilder
                .Ignore(p => p.Email);
            entityTypeBuilder
                .Ignore(p => p.JsonWebToken);
        }
        partial void ConfigureEntityType(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(p => p.Firstname)
                .HasMaxLength(64);
            entityTypeBuilder
                .Property(p => p.Lastname)
                .HasMaxLength(64);
        }
        #endregion Configuration
    }
}
//MdEnd
