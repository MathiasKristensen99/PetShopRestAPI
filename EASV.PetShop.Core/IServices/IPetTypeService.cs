using System.Collections.Generic;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        List<PetType> GetAllPetTypes();

        PetType GetPetType(int id);
    }
}