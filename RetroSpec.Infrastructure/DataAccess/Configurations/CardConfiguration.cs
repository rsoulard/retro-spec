using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroSpec.Core.CardModels;

namespace RetroSpec.Infrastructure.DataAccess.Configurations;

internal class CardConfiguration : IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable("Cards", "Retro");

        builder.HasKey(card => card.Id);
    }
}
