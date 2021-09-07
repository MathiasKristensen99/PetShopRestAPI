using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;

namespace EASV.PetShop.DataAccess
{
    public class OwnerRepository : IOwnerRepository
    {
        public List<Owner> AllOwners = new List<Owner>();
        private static int _id = 1;
        
        public List<Owner> GetAllOwners()
        {
            Owner owner1 = new Owner();
            owner1.Id = 1;
            owner1.Name = "Simon";
            AllOwners.Add(owner1);

            Owner owner2 = new Owner();
            owner2.Id = 2;
            owner2.Name = "Michael";
            AllOwners.Add(owner2);

            Owner owner3 = new Owner();
            owner3.Id = 3;
            owner3.Name = "Bo";
            AllOwners.Add(owner3);

            return AllOwners;
        }

        public List<Owner> ReadAllOwners()
        {
            return AllOwners;
        }

        public void CreateOwner(Owner owner)
        {
            Owner newOwner = new Owner();
            newOwner.Id = owner.Id;
            newOwner.Name = owner.Name;
            
            AllOwners.Add(newOwner);
        }

        public void UpdateOwnerName(int id, string name)
        {
            List<Owner> owners = AllOwners;

            owners.First(owner => owner.Id == id).Name = name;
        }

        public void DeleteOwner(int id)
        {
            List<Owner> owners = AllOwners;

            foreach (Owner owner in owners)
            {
                if (owner.Id.Equals(id))
                {
                    owners.Remove(owner);
                }
            }
        }

        public Owner GetOwnerById(int id)
        {
            List<Owner> owners = AllOwners;

            foreach (Owner owner in owners)
            {
                if (owner.Id.Equals(id))
                {
                    return owner;
                }
            }

            return null;
        }
    }
}