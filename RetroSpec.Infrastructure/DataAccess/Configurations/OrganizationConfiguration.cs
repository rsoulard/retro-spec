using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroSpec.Core.OrganizationModels;
using RetroSpec.Core.TeamModels;

namespace RetroSpec.Infrastructure.DataAccess.Configurations;

internal class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organizations", "Management");

        builder.HasKey(organization => organization.Id);

        builder.HasMany<Team>()
            .WithOne()
            .HasForeignKey(team => team.OrganizationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
