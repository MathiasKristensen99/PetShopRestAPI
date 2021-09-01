using System;
using System.Collections.Generic;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets();

        List<Pet> ReadAllPets();

        void CreatePet(Pet pet);

        void DeletePet(int id);

        void UpdatePetName(int id, string name);

        void UpdatePetId(int id, int newId);
        
        void UpdatePetType(int id, PetType type);

        void UpdateBirthDate(int id, DateTime birthdate);

        void UpdateSoldDate(int id, DateTime soldDate);

        void UpdatePetColor(int id, string color);

        void UpdatePetPrice(int id, double price);
    }
}