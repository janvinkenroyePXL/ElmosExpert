using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OutOfTheBox.Domain;

namespace OutOfTheBox.Infrastructure.EntityConfigurations
{
    internal class CellConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            builder
                .ToTable("cells");

            builder
                .HasKey(c => c.Id);

            builder.Property(c => c.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

            builder.HasOne(c => c.Prison)
                .WithMany(p => p.Cells);
        }
    }
}
