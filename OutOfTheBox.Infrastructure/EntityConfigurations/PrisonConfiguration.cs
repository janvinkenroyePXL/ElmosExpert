using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfTheBox.Domain;

namespace OutOfTheBox.Infrastructure.EntityConfigurations
{
    internal class PrisonConfiguration : IEntityTypeConfiguration<Prison>
    {
        public void Configure(EntityTypeBuilder<Prison> builder)
        {
            builder
                .ToTable("prisons");

            builder
                .HasKey(p => p.Id);

            builder.Property(p => p.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
        }
    }
}
