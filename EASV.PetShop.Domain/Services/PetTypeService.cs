using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;

        public PetTypeService(IPetTypeRepository repository)
        {
            _petTypeRepository = repository;
        }
        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepository.GetAllPetTypes();
        }

        public PetType GetPetType(int id)
        {
            return _petTypeRepository.GetPetType(id);
        }
    }
}