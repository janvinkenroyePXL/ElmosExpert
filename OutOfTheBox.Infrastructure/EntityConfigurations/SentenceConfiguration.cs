using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfTheBox.Domain;

namespace OutOfTheBox.Infrastructure.EntityConfigurations
{
    internal class SentenceConfiguration : IEntityTypeConfiguration<Sentence>
    {
        public void Configure(EntityTypeBuilder<Sentence> builder)
        {
            builder
                .ToTable("sentences");

            builder
                .HasKey(s => s.Id);

            builder.Property(s => s.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
        }
    }
}
