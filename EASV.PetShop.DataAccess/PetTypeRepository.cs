using System.Collections.Generic;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.DataAccess
{
    public class PetTypeRepository : IPetTypeRepository
    {
        public List<PetType> GetAllPetTypes()
        {
            List<PetType> allPetTypes = new List<PetType>();

            PetType petType1 = new PetType();
            petType1.Id = 1;
            petType1.Name = "Dog";
            allPetTypes.Add(petType1);

            PetType petType2 = new PetType();
            petType2.Id = 2;
            petType2.Name = "Cat";
            allPetTypes.Add(petType2);

            PetType petType3 = new PetType();
            petType3.Id = 3;
            petType3.Name = "Goat";
            allPetTypes.Add(petType3);
            
            return allPetTypes;
        }

        public PetType GetPetType(int id)
        {
            List<PetType> petTypes = GetAllPetTypes();

            foreach (PetType petType in petTypes)
            {
                if (petType.Id.Equals(id))
                {
                    return petType;
                }
            }

            return null;
        }
    }
}