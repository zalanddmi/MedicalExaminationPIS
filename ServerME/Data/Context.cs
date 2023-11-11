using Microsoft.EntityFrameworkCore;
using ServerME.Models;

namespace ServerME.Data
{
    public class Context : DbContext
    {
        public Context()
        {
            
        }
        public Context(string? created)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=12345;Database=testdb");
        }

        public DbSet<TypeOrganization> TypeOrganizations { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MunicipalContract> MunicipalContracts { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Cost> Costs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //тип организаций
            modelBuilder.Entity<TypeOrganization>(
            entity =>
            {
                entity.HasKey(p => p.IdTypeOrganization);

                entity.Property(p => p.Name)
                    .HasMaxLength(100);

                entity.HasIndex(p => p.Name)
                    .IsUnique();
            });

            //муниципалитет 
            modelBuilder.Entity<Municipality>(
            entity =>
            {
                entity.HasKey(p => p.IdMunicipality);

                entity.Property(p => p.Name)
                    .HasMaxLength(50);

                entity.HasIndex(p => p.Name)
                    .IsUnique();
            });


            //нас. пункт
            modelBuilder.Entity<Locality>(
            entity =>
            {
                entity.HasKey(p => p.IdLocality);

                entity.Property(p => p.Name)
                    .HasMaxLength(50);

                entity.HasIndex(p => p.Name)
                    .IsUnique();
            });

            //организация 
            modelBuilder.Entity<Organization>(
            entity =>
            {
                entity.HasKey(p => p.IdOrganization);
                entity.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.TaxIdNumber)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.CodeReason)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.Address)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasIndex(p => p.Name)
                    .IsUnique();
                entity.HasIndex(p => p.TaxIdNumber)
                    .IsUnique();
                entity.HasIndex(p => p.CodeReason)
                    .IsUnique();
            });

            //контракты
            modelBuilder.Entity<MunicipalContract>(
            entity =>
            {
                entity.HasKey(p => p.IdMunicipalContract);

                entity.Property(p => p.Number)
                    .HasMaxLength(50);

                entity.HasIndex(p => p.Number)
                    .IsUnique();

                entity.Property(p => p.DateAction)
                    .HasColumnType("date");

                entity.Property(p => p.DateConclusion)
                    .HasColumnType("date");
            });

            //животное
            modelBuilder.Entity<Animal>(
            entity =>
            {
                entity.HasKey(p => p.IdAnimal);
                entity.Property(p => p.Name)
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(p => p.RegNumber)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.Category)
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(p => p.SexAnimal)
                    .HasMaxLength(10)
                    .IsRequired();
                entity.Property(p => p.NumberElectronicChip)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.HasIndex(p => p.RegNumber)
                    .IsUnique();
                entity.HasIndex(p => p.NumberElectronicChip)
                    .IsUnique();
            });

            //роль
            modelBuilder.Entity<Role>(
            entity =>
            {
                entity.HasKey(p => p.IdRole);
                entity.Property(p => p.Name)
                    .HasMaxLength(50);
                entity.HasIndex(p => p.Name)
                    .IsUnique();
            });

            //пользователь
            modelBuilder.Entity<User>(
            entity =>
            {
                entity.HasKey(p => p.IdUser);
                entity.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.Post)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.Login)
                    .HasMaxLength(50)
                    .IsRequired();
                entity.Property(p => p.Password)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasIndex(p => p.Login)
                    .IsUnique();
            });

            //осмотры
            modelBuilder.Entity<Examination>(
            entity =>
            {
                entity.HasKey(p => p.IdExamination);
                entity.HasOne<Organization>(p => p.Organization).WithMany().OnDelete(DeleteBehavior.Restrict);
                entity.Property(p => p.PeculiaritiesBehavior)
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(p => p.ConditionAnimal)
                    .HasMaxLength(25)
                    .IsRequired();
                entity.Property(p => p.Temperature)
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(p => p.Skin)
                    .HasMaxLength(20)
                    .IsRequired();
                entity.Property(p => p.Wool)
                    .HasMaxLength(30)
                    .IsRequired();
                entity.Property(p => p.Damage)
                    .HasMaxLength(30)
                    .IsRequired();
                entity.Property(p => p.Diagnosis)
                    .HasMaxLength(30)
                    .IsRequired();
                entity.Property(p => p.Manipulations)
                    .HasMaxLength(30)
                    .IsRequired();
                entity.Property(p => p.Treatment)
                    .HasMaxLength(30)
                    .IsRequired();

                entity.Property(p => p.DateExamination)
                    .HasColumnType("date");
            });

            //цены
            modelBuilder.Entity<Cost>(
            entity =>
            {
                entity.HasKey(p => p.IdCost);
            });
        }
    }
}
