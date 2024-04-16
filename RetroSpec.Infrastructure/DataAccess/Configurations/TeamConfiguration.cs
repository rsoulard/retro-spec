using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroSpec.Core.BoardModels;
using RetroSpec.Core.TeamModels;

namespace RetroSpec.Infrastructure.DataAccess.Configurations
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams", "Management");

            builder.HasKey(team => team.Id);

            builder.HasMany<Board>()
                .WithOne()
                .HasForeignKey(board => board.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
