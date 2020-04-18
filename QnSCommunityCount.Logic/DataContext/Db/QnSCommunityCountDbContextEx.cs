using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QnSCommunityCount.Logic.Entities.Persistence.App;

namespace QnSCommunityCount.Logic.DataContext.Db
{
    partial class QnSCommunityCountDbContext
    {
        partial void ConfigureEntityType(EntityTypeBuilder<CostCollection> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasIndex(p => p.Designation)
                .IsUnique();
            entityTypeBuilder
                .Property(p => p.Designation)
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Description)
                .HasMaxLength(1024);
            entityTypeBuilder
                .Property(p => p.Members)
                .IsRequired()
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Currency)
                .IsRequired()
                .HasMaxLength(10);
        }
        partial void ConfigureEntityType(EntityTypeBuilder<CostRecord> entityTypeBuilder)
        {
            entityTypeBuilder
                .Property(p => p.Designation)
                .IsRequired()
                .HasMaxLength(256);
            entityTypeBuilder
                .Property(p => p.Member)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
