using EASV.PetShop.SQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShop.SQL
{
    public class PetShopDBContext : DbContext
    {
        
        public DbSet<InsuranceEntity> Insurances { get; set; } 
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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