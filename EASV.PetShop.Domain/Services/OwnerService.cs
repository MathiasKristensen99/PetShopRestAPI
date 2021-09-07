using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;

namespace EASV.PetShop.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners();
        }

        public List<Owner> ReadAllOwners()
        {
            return _ownerRepository.ReadAllOwners();
        }

        public void CreateOwner(Owner owner)
        {
            _ownerRepository.CreateOwner(owner);
        }

        public void UpdateOwnerName(int id, string name)
        {
            _ownerRepository.UpdateOwnerName(id, name);
        }

        public void DeleteOwner(int id)
        {
            _ownerRepository.DeleteOwner(id);
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }
    }
}