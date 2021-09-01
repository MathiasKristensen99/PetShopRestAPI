using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.DataAccess
{
    public class PetRepository : IPetRepository
    {
        public List<Pet> allPets = new List<Pet>();
        
        public List<Pet> GetAllPets()
        {
            PetType petType1 = new PetType();
            petType1.Id = 1;
            petType1.Name = "Dog";

            PetType petType2 = new PetType();
            petType2.Id = 2;
            petType2.Name = "Cat";

            PetType petType3 = new PetType();
            petType3.Id = 3;
            petType3.Name = "Goat";
            
            Pet pet1 = new Pet();
            pet1.Id = 1;
            pet1.Name = "Mike";
            pet1.BirthDate = DateTime.Today;
            pet1.SoldDate = DateTime.Today;
            pet1.Color = "Black";
            pet1.Type = petType1;
            pet1.Price = 5000;
            allPets.Add(pet1);

            Pet pet2 = new Pet();
            pet2.Id = 2;
            pet2.Name = "Charles";
            pet2.BirthDate = DateTime.Today;
            pet2.SoldDate = DateTime.Today;
            pet2.Color = "White";
            pet2.Type = petType2;
            pet2.Price = 2000;
            allPets.Add(pet2);

            Pet pet3 = new Pet();
            pet3.Id = 3;
            pet3.Name = "Rasmus";
            pet3.BirthDate = DateTime.Today;
            pet3.SoldDate = DateTime.Today;
            pet3.Color = "Orange";
            pet3.Type = petType3;
            pet3.Price = 10000;
            allPets.Add(pet3);

            Pet pet4 = new Pet();
            pet4.Id = 4;
            pet4.Name = "Julian";
            pet4.BirthDate = DateTime.Today;
            pet4.SoldDate = DateTime.Today;
            pet4.Color = "Brown";
            pet4.Type = petType1;
            pet4.Price = 8000;
            allPets.Add(pet4);

            Pet pet5 = new Pet();
            pet5.Id = 5;
            pet5.Name = "Simon";
            pet5.BirthDate = DateTime.Today;
            pet5.SoldDate = DateTime.Today;
            pet5.Color = "Black";
            pet5.Type = petType2;
            pet5.Price = 4000;
            allPets.Add(pet5);
            
            return allPets;
        }

        public List<Pet> ReadAllPets()
        {
            return allPets;
        }

        public void CreatePet(Pet pet)
        {
            Pet newPet = new Pet();
            newPet.Id = pet.Id;
            newPet.Name = pet.Name;
            newPet.Price = pet.Price;
            newPet.Type = pet.Type;
            newPet.Color = pet.Color;
            newPet.BirthDate = pet.BirthDate;
            newPet.SoldDate = pet.SoldDate;
            
            allPets.Add(newPet);
        }

        public void DeletePet(int id)
        {
            List<Pet> pets = allPets;

            foreach (Pet pet in pets.ToList())
            {
                if (pet.Id.Equals(id))
                {
                    pets.Remove(pet);
                }
            }
        }

        public void UpdatePetName(int id, string name)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).Name = name;
            
            Console.WriteLine("Name has been updated to: " + name + ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name);
            }
        }

        public void UpdatePetId(int id, int newId)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).Id = newId;
            
            Console.WriteLine("Id has been updated to: " + newId + ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name + " Id: " + id);
            }
        }

        public void UpdatePetType(int id, PetType type)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).Type = type;
            
            Console.WriteLine("Pet type has been updated to: " + type.Name + ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name + " Type: " + pet.Type.Name);
            }
        }

        public void UpdateBirthDate(int id, DateTime birthdate)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).BirthDate = birthdate;
            
            Console.WriteLine("Birthdate has been updated to: " + birthdate+ ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name + " Birthdate: " + pet.BirthDate);
            }
        }

        public void UpdateSoldDate(int id, DateTime soldDate)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).SoldDate = soldDate;
            
            Console.WriteLine("Sold date has been updated to: " + soldDate+ ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name + " Sold date: " + pet.SoldDate);
            }
        }

        public void UpdatePetColor(int id, string color)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).Color = color;
            
            Console.WriteLine("Color has been updated to: " + color+ ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name + " Color: " + pet.Color);
            }
            
        }

        public void UpdatePetPrice(int id, double price)
        {
            List<Pet> pets = allPets;

            pets.First(pet => pet.Id == id).Price = price;
            
            Console.WriteLine("Price has been updated to: " + price+ ", press 0 to go back");
            
            foreach (Pet pet in pets)
            {
                Console.WriteLine("Name: " + pet.Name + " Price: " + pet.Price);
            }
        }
    }
}