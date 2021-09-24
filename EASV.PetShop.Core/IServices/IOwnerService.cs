using System.Collections.Generic;
using EASV.PetShop.Core.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IOwnerService
    {
        List<Owner> ReadAllOwners();

        Owner CreateOwner(Owner owner);

        Owner UpdateOwnerName(int id, string name);

        Owner DeleteOwner(int id);

        Owner GetOwnerById(int id);
    }
}