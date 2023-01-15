using Microsoft.EntityFrameworkCore;
using OutOfTheBox.Domain;
using OutOfTheBox.Infrastructure.EntityConfigurations;

namespace OutOfTheBox.Infrastructure
{
    public class OutOfTheBoxContext : DbContext
    {
        public DbSet<Prison> Prisons { get; set; } = null!;
        public DbSet<Cell> Cells { get; set; } = null!;
        public DbSet<Prisoner> Prisoners { get; set; } = null!;
        public DbSet<Sentence> Sentences { get; set; } = null!;
        public DbSet<Rivalry> Rivalries { get; set; } = null!;

        public OutOfTheBoxContext(DbContextOptions<OutOfTheBoxContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PrisonConfiguration());
            builder.ApplyConfiguration(new CellConfiguration());
            builder.ApplyConfiguration(new PrisonerConfiguration());
            builder.ApplyConfiguration(new SentenceConfiguration());
            builder.ApplyConfiguration(new RivalryConfiguration());
        }
    }
}