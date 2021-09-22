using EASV.PetShop.SQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShop.SQL
{
    public class PetShopDBContext : DbContext
    {
        
        public DbSet<InsuranceEntity> Insurances { get; set; } 
        
        public DbSet<PetEntity> Pets { get; set; }
        
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        
        public DbSet<OwnerEntity> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>().HasOne(petEntity => petEntity.Insurance).WithMany();
            
            
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity
                {
                    Id = 1,
                    Name = "Safestuff"
                });
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity
                {
                    Id = 2,
                    Name = "Goodstuff"
                });
            modelBuilder.Entity<InsuranceEntity>()
                .HasData(new InsuranceEntity
                {
                    Id = 3,
                    Name = "Nicestuff"
                });
        }

        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options) { }
        
    }
}