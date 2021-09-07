using System.Collections.Generic;
using EASV.PetShop.Core.Models;

namespace EASV.PetShop.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        List<Owner> ReadAllOwners();

        void CreateOwner(Owner owner);

        void UpdateOwnerName(int id, string name);

        void DeleteOwner(int id);

        Owner GetOwnerById(int id);
    }
}