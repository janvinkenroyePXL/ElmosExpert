using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfTheBox.Domain;

namespace OutOfTheBox.Infrastructure.EntityConfigurations
{
    internal class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> builder)
        {
            builder
                .ToTable("prisoners");

            builder
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

            builder.HasOne(p => p.Cell)
                .WithMany(c => c.Prisoners);

            builder.HasOne(p => p.Sentence)
                .WithOne(s => s.Prisoner)
                .HasForeignKey<Sentence>(s => s.PrisonerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
