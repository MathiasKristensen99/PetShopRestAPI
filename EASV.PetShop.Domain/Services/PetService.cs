using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Filtering;
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

        public int TotalCount()
        {
            return _petRepository.TotalCount();
        }

        public List<Pet> ReadAllPets(Filter filter)
        {
            if (filter == null || filter.Limit <= 0 || filter.Limit > 100)
            {
                throw new ArgumentException("Filter limit must be between 1 and 100");
            }

            var totalCount = TotalCount();
            var maxPageCount = Math.Ceiling((double)totalCount / filter.Limit);
            
            if (filter.Page < 1 || filter.Page > maxPageCount)
            {
                throw new ArgumentException($"Filter page must be above 1 and {maxPageCount}");
            }
            return _petRepository.ReadAllPets(filter);
        }

        public Pet GetById(int id)
        {
            return _petRepository.GetById(id);
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.DeletePet(id);
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