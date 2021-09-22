using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;
using EASV.PetShop.SQL.Entities;

namespace EASV.PetShop.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopDBContext _ctx;

        public PetRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<Pet> GetAllPets()
        {
            throw new NotImplementedException();
        }

        public List<Pet> ReadAllPets()
        {
            return _ctx.Pets.Select(pet => new Pet
            {
                Id = pet.Id,
                Name = pet.Name,
                Color = pet.Color,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                Price = pet.Price
            }).ToList();
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
                Name = pet.Name
            }).Entity;
            
            _ctx.SaveChanges();
            
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name
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