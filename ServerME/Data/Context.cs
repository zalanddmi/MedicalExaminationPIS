using Microsoft.EntityFrameworkCore;
using ServerME.Models;
using ServerME.Utils;

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
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=Mu$@2001;Database=testdb");
            //optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
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
        public DbSet<Log> Logs { get; set; }
        public DbSet<Report> Reports { get; set; }
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

                entity.HasMany(p => p.ContractsExecutor)
                .WithOne(p => p.Executor).OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(p => p.ContractsCustomer)
                .WithOne(p => p.Customer).OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(p => p.Users)
                .WithOne(p => p.Organization).OnDelete(DeleteBehavior.ClientNoAction);

                entity.HasMany(p => p.Examinations)
                .WithOne(p => p.Organization).OnDelete(DeleteBehavior.ClientNoAction);

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

                entity.HasMany(p => p.Examinations)
                .WithOne(p => p.MunicipalContract).OnDelete(DeleteBehavior.ClientNoAction);
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

                entity.HasMany(p => p.Examinations)
                .WithOne(p => p.Animal).OnDelete(DeleteBehavior.ClientNoAction);
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

            //журнал
            modelBuilder.Entity<Log>(
            entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Date)
                    .HasColumnType("timestamp");
            });

            //отчеты
            modelBuilder.Entity<Report>(
            entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.StartDate)
                    .HasColumnType("timestamp");
                entity.Property(p => p.EndDate)
                    .HasColumnType("timestamp");
                entity.Property(p => p.StatusDate)
                    .HasColumnType("timestamp");
            });
        }
    }
}
