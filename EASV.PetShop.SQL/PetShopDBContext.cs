using System;
using EASV.PetShop.Core.Models;
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
        
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PetEntity>().HasData(new PetEntity
            {
                Id = 1,
                Name = "James",
                BirthDate = DateTime.Now,
                SoldDate = DateTime.Now,
                Price = 2000,
                Color = "Black",
                InsuranceId = 1,
                PetTypeId = 1,
                OwnerId = 1
            });
            
            modelBuilder.Entity<PetEntity>().HasData(new PetEntity
            {
                Id = 2,
                Name = "Mike",
                BirthDate = DateTime.Now,
                SoldDate = DateTime.Now,
                Price = 3000,
                Color = "Red",
                InsuranceId = 2,
                PetTypeId = 2,
                OwnerId = 2
            });

            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity
            {
                Id = 1,
                Name = "Dog"
            });

            modelBuilder.Entity<PetTypeEntity>().HasData(new PetTypeEntity
            {
                Id = 2,
                Name = "Cat"
            });

            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 1,
                Name = "Simon"
            });

            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity
            {
                Id = 2,
                Name = "Rasmus"
            });
            
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
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.PetType).WithMany()
                .HasForeignKey(petEntity => new {petEntity.PetTypeId});
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Insurance).WithMany();
            
            modelBuilder.Entity<PetEntity>()
                .HasOne(petEntity => petEntity.Owner).WithMany();
        }

        public PetShopDBContext(DbContextOptions<PetShopDBContext> options) : base(options) { }
        
    }
}