using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfTheBox.Domain;

namespace OutOfTheBox.Infrastructure.EntityConfigurations
{
    internal class RivalryConfiguration : IEntityTypeConfiguration<Rivalry>
    {
        public void Configure(EntityTypeBuilder<Rivalry> builder)
        {
            builder
                .ToTable("rivalries");

            builder
                .HasKey(r => new { r.PrisonerId, r.RivalId});

            builder
                .HasOne<Prisoner>(r => r.Prisoner)
                .WithMany(p => p.ActiveRivalries)
                .HasForeignKey(r => r.PrisonerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne<Prisoner>(r => r.Rival)
                .WithMany(p => p.PassiveRivalries)
                .HasForeignKey(r => r.RivalId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
