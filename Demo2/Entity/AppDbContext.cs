using Microsoft.EntityFrameworkCore;

namespace Demo2.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pokemon> Pokemon {get; set;}
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<PokemonOwners> PokemonOwners { get; set; }

        public DbSet<PokemonCategories> PokemonCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCategories>()
                        .HasKey(pc => new { pc.PokemonId, pc.CategoryId });
            modelBuilder.Entity<PokemonCategories>()
                        .HasOne(p => p.Pokemon)
                        .WithMany(pc => pc.PokemonCategories)
                        .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonCategories>()
                        .HasOne(p => p.Category)
                        .WithMany(pc => pc.PokemonCategories)
                        .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<PokemonOwners>()
                        .HasKey(po => new { po.PokemonId, po.OwnerId });
            modelBuilder.Entity<PokemonOwners>()
                        .HasOne(p => p.Pokemon)
                        .WithMany(po => po.PokemonOwners)
                        .HasForeignKey(p => p.PokemonId);
            modelBuilder.Entity<PokemonOwners>()
                        .HasOne(p => p.Owner)
                        .WithMany(po => po.PokemonOwners)
                        .HasForeignKey(o => o.OwnerId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var strConn = config["ConnectionStrings:DefaultConnectionStrings"];
            return strConn;
        }
    }
}
