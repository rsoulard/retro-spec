using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroSpec.Core.BoardModels;
using RetroSpec.Core.CardModels;

namespace RetroSpec.Infrastructure.DataAccess.Configurations;

internal class ColumnConfiguration : IEntityTypeConfiguration<Column>
{
    public void Configure(EntityTypeBuilder<Column> builder)
    {
        builder.ToTable("Columns", "Retro");

        builder.HasKey("Id", "BoardId");

        builder.HasMany<Card>()
            .WithOne()
            .HasForeignKey("ColumnId", "BoardId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
