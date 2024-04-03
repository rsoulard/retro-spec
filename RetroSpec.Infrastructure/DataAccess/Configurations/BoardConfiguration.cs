using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroSpec.Core.BoardModels;

namespace RetroSpec.Infrastructure.DataAccess.Configurations;

internal class BoardConfiguration : IEntityTypeConfiguration<Board>
{
    public void Configure(EntityTypeBuilder<Board> builder)
    {
        builder.ToTable("Boards", "Retro");

        builder.HasKey(board => board.Id);

        builder.HasMany(board => board.Columns)
            .WithOne()
            .HasForeignKey("BoardId")
            .OnDelete(DeleteBehavior.Cascade)
            .Metadata.PrincipalToDependent?.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
