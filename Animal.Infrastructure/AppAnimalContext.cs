using Animal.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Animal.Infrastructure
{
    public class AppAnimalContext : DbContext{
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<ShelterLocation> ShelterLocations { get; set; }
        public DbSet<Specie> Species { get; set; }

        public DbSet<AnimalEntity> Animals { get; set; }

        public AppAnimalContext(){}
        public AppAnimalContext(DbContextOptions<AppAnimalContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnimalEntity>()
                .HasOne(a => a.SheltherLocation)
                .WithMany(sl => sl.Animals)
                .HasForeignKey(a => a.SheltherLocationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ShelterLocation)
                .WithMany(sl => sl.Employees)
                .HasForeignKey(e => e.ShelterLocationId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Animal)
                .WithMany()
                .HasForeignKey(a => a.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Adoption>()
                .HasOne(a => a.Adopter)
                .WithMany()
                .HasForeignKey(a => a.AdopterId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalRecord>()
                .HasOne(mr => mr.Animal)
                .WithMany()
                .HasForeignKey(mr => mr.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Server=localhost;Database=AnimalDb;User Id=postgres;Password=123456;");
            optionsBuilder.UseNpgsql("Host=ep-restless-tree-a87x17dk-pooler.eastus2.azure.neon.tech;Database=neondb;Username=neondb_owner;Password=npg_Xw3F4AUMkluV");
        }
    }
}
