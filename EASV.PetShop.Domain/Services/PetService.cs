using System;
using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(IPetRepository repository)
        {
            _petRepository = repository;
        }
        
        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets();
        }

        public List<Pet> ReadAllPets()
        {
            return _petRepository.ReadAllPets();
        }

        public void CreatePet(Pet pet)
        {
            _petRepository.CreatePet(pet);
        }

        public void DeletePet(int id)
        {
            _petRepository.DeletePet(id);
        }

        public void UpdatePetName(int id, string name)
        {
            _petRepository.UpdatePetName(id, name);
        }

        public void UpdatePetId(int id, int newId)
        {
            _petRepository.UpdatePetId(id, newId);
        }

        public void UpdatePetType(int id, PetType type)
        {
            _petRepository.UpdatePetType(id, type);
        }

        public void UpdateBirthDate(int id, DateTime birthdate)
        {
            _petRepository.UpdateBirthDate(id, birthdate);
        }

        public void UpdateSoldDate(int id, DateTime soldDate)
        {
            _petRepository.UpdateSoldDate(id, soldDate);
        }

        public void UpdatePetColor(int id, string color)
        {
            _petRepository.UpdatePetColor(id, color);
        }

        public void UpdatePetPrice(int id, double price)
        {
            _petRepository.UpdatePetPrice(id, price);
        }
    }
}