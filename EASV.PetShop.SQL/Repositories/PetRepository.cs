using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Filtering;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;
using EASV.PetShop.SQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EASV.PetShop.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDBContext _ctx;

        public PetRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }

        public int TotalCount()
        {
            return _ctx.Pets.Count();
        }

        public List<Pet> ReadAllPets(Filter filter)
        {
            var selectQuery = _ctx.Pets
                .Include(pet => pet.Insurance)
                .Include(pet => pet.Owner)
                .Include(pet => pet.PetType)
                .Select(petEntity => new Pet
                {
                    Id = petEntity.Id,
                    Name = petEntity.Name,
                    Color = petEntity.Color,
                    BirthDate = petEntity.BirthDate,
                    SoldDate = petEntity.SoldDate,
                    Price = petEntity.Price,
                    Insurance = new Insurance
                    {
                        Id = petEntity.Insurance.Id,
                        Name = petEntity.Insurance.Name
                    },
                    Owner = new Owner
                    {
                        Id = petEntity.Owner.Id,
                        Name = petEntity.Owner.Name
                    },
                    PetType = new PetType
                    {
                        Id = petEntity.PetType.Id,
                        Name = petEntity.PetType.Name
                    }
                }).ToList();
            
            if (filter.OrderDir.ToLower().Equals("asc"))
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "Name":
                        selectQuery.OrderBy(pet => pet.Name);
                        break;
                    case "Id":
                        selectQuery.OrderBy(pet => pet.Id);
                        break;
                }
            }
            else
            {
                switch (filter.OrderBy.ToLower())
                {
                    case "Name":
                        selectQuery.OrderByDescending(pet => pet.Name);
                        break;
                    case "Id":
                        selectQuery.OrderByDescending(pet => pet.Id);
                        break;
                }
                selectQuery.OrderByDescending(entity => entity.Name);
            }
            
            var query = selectQuery
                .Skip((filter.Page - 1) * filter.Limit)
                .Take(filter.Limit);
            
            return query.ToList();
        }

        public Pet GetById(int id)
        {
            return _ctx.Pets
                .Select(pet => new Pet
                {
                    Id = pet.Id,
                    Name = pet.Name
                }).FirstOrDefault(pet => pet.Id == id);
        }

        public Pet CreatePet(Pet pet)
        {
            var entity = _ctx.Add(new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                Color = pet.Color,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                PetTypeId = pet.PetType.Id,
                OwnerId = pet.Owner.Id,
                InsuranceId = pet.Insurance.Id,
                Price = pet.Price
            }).Entity;
            
            _ctx.SaveChanges();
            
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
                Price = entity.Price
            };
        }

        public Pet DeletePet(int id)
        {
            var entity = _ctx.Pets.Remove(new PetEntity {Id = id}).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public void UpdatePetName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetId(int id, int newId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetType(int id, PetType type)
        {
            throw new NotImplementedException();
        }

        public void UpdateBirthDate(int id, DateTime birthdate)
        {
            throw new NotImplementedException();
        }

        public void UpdateSoldDate(int id, DateTime soldDate)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetColor(int id, string color)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetPrice(int id, double price)
        {
            throw new NotImplementedException();
        }
    }
}