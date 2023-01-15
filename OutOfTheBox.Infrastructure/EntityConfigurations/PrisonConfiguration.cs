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

            /*
            builder.HasData(
                new Student()
                {
                    Id = 1,
                    UserId = 1,
                },
                new Student()
                {
                    Id = 2,
                    UserId = 2,
                },
                new Student()
                {
                    Id = 3,
                    UserId = 3,
                },
                new Student()
                {
                    Id = 4,
                    UserId = 4,
                },
                new Student()
                {
                    Id = 5,
                    UserId = 5,
                },
                new Student()
                {
                    Id = 6,
                    UserId = 6,
                },
                new Student()
                {
                    Id = 7,
                    UserId = 7,
                },
                new Student()
                {
                    Id = 8,
                    UserId = 8,
                },
                new Student()
                {
                    Id = 9,
                    UserId = 9,
                },
                new Student()
                {
                    Id = 10,
                    UserId = 10,
                },
                new Student()
                {
                    Id = 11,
                    UserId = 11,
                },
                new Student()
                {
                    Id = 12,
                    UserId = 12,
                },
                new Student()
                {
                    Id = 13,
                    UserId = 13,
                },
                new Student()
                {
                    Id = 14,
                    UserId = 14,
                },
                new Student()
                {
                    Id = 15,
                    UserId = 15,
                },
                new Student()
                {
                    Id = 16,
                    UserId = 16,
                }
            );
            */
        }
    }
}
