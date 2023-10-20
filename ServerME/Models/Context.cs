using Microsoft.EntityFrameworkCore;

namespace ServerME.Models
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public Context(string? created)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=Mu$@2001;Database=testdb");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MunicipalContract> Contracts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<TypeOrganization> TypeOrganizations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(p => p.IdUser).IsRequired();
        }
    }
}
