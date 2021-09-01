using System.Collections.Generic;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        List<PetType> GetAllPetTypes();

        PetType GetPetType(int id);
    }
}