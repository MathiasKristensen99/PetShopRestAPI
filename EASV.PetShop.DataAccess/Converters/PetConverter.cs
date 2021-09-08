﻿using EASV.PetShop.Core.Models;
using EASV.PetShop.DataAccess.Entities;

namespace EASV.PetShop.DataAccess.Converters
{
    public class PetConverter
    {
        public Pet Convert(PetEntity entity)
        {
            return new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Price = entity.Price,
                BirthDate = entity.BirthDate,
                SoldDate = entity.SoldDate,
            };
        }

        public PetEntity Convert(Pet pet)
        {
            return new PetEntity
            {
                Id = pet.Id,
                Name = pet.Name,
                Color = pet.Color,
                Price = pet.Price,
                BirthDate = pet.BirthDate,
                SoldDate = pet.SoldDate,
                PetTypeId = pet.Type != null ? pet.Type.Id : 0,
                OwnerId = pet.Owner != null ? pet.Owner.Id : 0
            };
        }
    }
}