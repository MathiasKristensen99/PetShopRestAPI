using System;
using System.Collections.Generic;
using System.Linq;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.Models;

namespace EASV.PetShop.UI
{
    internal class Menu
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;

        public Menu(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }

        public void Start()
        {
            _petService.GetAllPets();
            ShowWelcomeGreeting();
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                if (choice == 1)
                {
                    ShowAllPets();
                }

                if (choice == 2)
                {
                    CreatePet();
                }

                if (choice == 3)
                {
                    DeletePet();
                }

                if (choice == 4)
                {
                    UpdatePet();
                }

                if (choice == 5)
                {
                    GetPetByPetType();
                }

                if (choice == 6)
                {
                    ShowMostExpensivePets();
                }

                if (choice == 7)
                {
                    ShowCheapestPets();
                }
            }
        }

        private void ShowAllPets()
        {
            List<Pet> allPets = _petService.ReadAllPets();

            foreach (Pet pet in allPets)
            {
                Console.WriteLine("Id: " + pet.Id + " Name: " + pet.Name + " Color: " + pet.Color + " Type: " + pet.Type.Name + " Birthdate: " + pet.BirthDate + " Price: " + pet.Price + " SoldDate: " + pet.SoldDate);
            }
            Console.WriteLine("\n");
        }

        private void ShowCheapestPets()
        {
            List<Pet> pets = _petService.ReadAllPets();

            List<Pet> sortedPets = pets.OrderBy(pet => pet.Price).ToList();

            foreach (Pet pet in sortedPets)
            {
                Console.WriteLine("Name: " + pet.Name + " Price: " + pet.Price);
            }
            Console.WriteLine("\n");
        }

        private void ShowMostExpensivePets()
        {
            List<Pet> pets = _petService.ReadAllPets();

            List<Pet> sortedPets = pets.OrderByDescending(pet => pet.Price).ToList();
            
            foreach (Pet pet in sortedPets)
            {
                Console.WriteLine("Name: " + pet.Name + " Price: " + pet.Price);
            }
            Console.WriteLine("\n");
        }

        private void ShowAllPetTypes()
        {
            List<PetType> petTypes = _petTypeService.GetAllPetTypes();

            foreach (PetType petType in petTypes)
            {
                Console.WriteLine("Id: " + petType.Id + " Name: " + petType.Name);
            }
        }
        
        private void DeletePet()
        {
            ShowAllPets();
            Console.WriteLine("Select a pet to delete, by typing the id and hit enter");
            
            var idString = Console.ReadLine();
            int idToDelete = 0;
            int id;

            if (int.TryParse(idString, out id))
            {
                idToDelete = id;
            }
            
            _petService.DeletePet(idToDelete);
            
            Console.WriteLine("The pet has been deleted");
        }
        
        private void GetPetByPetType()
        {
            ShowAllPetTypes();

            List<Pet> pets = _petService.ReadAllPets();
            
            int choice = GetPetTypeSelection();
            
            foreach (Pet pet in pets)
            {
                if (choice.Equals(pet.Type.Id))
                {
                    Console.WriteLine("Name: " + pet.Name);
                }
            }
        }
        
        private void CreatePet()
        {
            List<Pet> pets = _petService.ReadAllPets();
            Pet pet = new Pet();
            
            Console.WriteLine(StringConstants.Id);
            var idString = Console.ReadLine();
            int id;

            if (int.TryParse(idString, out id))
            {
                pet.Id = id;
            }
            
            Console.WriteLine(StringConstants.Name);
            var name = Console.ReadLine();
            pet.Name = name;
            
            Console.WriteLine(StringConstants.Color);
            var color = Console.ReadLine();
            pet.Color = color;
            
            Console.WriteLine(StringConstants.Type);
            List<PetType> petTypes = _petTypeService.GetAllPetTypes();
            
            foreach (PetType petType in petTypes)
            {
                Console.WriteLine(petType.Id + ". " + petType.Name);
            }

            pet.Type = _petTypeService.GetPetType(GetPetTypeSelection());
            
            Console.WriteLine(pet.Type.Name);
            
            Console.WriteLine(StringConstants.Price);
            var priceString = Console.ReadLine();
            double price;

            if (double.TryParse(priceString, out price))
            {
                pet.Price = price;
            }
            
            Console.WriteLine(StringConstants.BirthDate);
            string birthDay = Console.ReadLine();
            var parsedBirthDay = DateTime.Parse(birthDay);

            pet.BirthDate = parsedBirthDay;
            
            Console.WriteLine(StringConstants.SoldDate);
            string soldDate = Console.ReadLine();
            var parsedSoldDate = DateTime.Parse(soldDate);

            pet.SoldDate = parsedSoldDate;
            
            pets.Add(pet);
            
            Console.WriteLine("You have added a new pet");
            Console.WriteLine(" Id: " + pet.Id + " Name: " + pet.Name + " Color: " + pet.Color + " Type: "
                              + pet.Type + " Price: " + pet.Price + " Birthdate: " + pet.BirthDate
                              + " Sold date: " + pet.SoldDate);
        }

        private void UpdatePet()
        {
            ShowAllPets();
            
            Console.WriteLine("Select a pet to update, by typing the id and hit enter");

            var idString = Console.ReadLine();
            int idToUpdate = 0;
            int id;

            if (int.TryParse(idString, out id))
            {
                idToUpdate = id;
            }
            
            Console.WriteLine("Choose what you want to update: ");
            Console.WriteLine("1. Id");
            Console.WriteLine("2. Name");
            Console.WriteLine("3. Type");
            Console.WriteLine("4. Birthdate");
            Console.WriteLine("5. Sold date");
            Console.WriteLine("6. Color");
            Console.WriteLine("7. Price");
            Console.WriteLine("8. Cancel");
            
            int choice;
            while ((choice = GetUpdatePetSelection()) != 0)
            {
                if (choice == 1)
                {
                    Console.WriteLine("Type a new Id");
                    var newIdString = Console.ReadLine();
                    int newId;

                    if (int.TryParse(newIdString, out newId))
                    {
                        _petService.UpdatePetId(idToUpdate, newId);
                    }
                    Console.WriteLine("\n");
                }
                
                if (choice == 2)
                {
                    Console.WriteLine("Type a new name:");
                    var updatedName = Console.ReadLine();
                    
                    _petService.UpdatePetName(idToUpdate, updatedName);
                    Console.WriteLine("\n");
                }

                if (choice == 3)
                {
                    Console.WriteLine("Pick a new pet type: ");
                    List<PetType> petTypes = _petTypeService.GetAllPetTypes();
                    
                    foreach (PetType petType in petTypes)
                    {
                        Console.WriteLine("Id: " + petType.Id + " Name: " + petType.Name);
                    }
                    
                    _petService.UpdatePetType(idToUpdate, _petTypeService.GetPetType(GetPetTypeSelection()));
                    
                    Console.WriteLine("\n");
                }

                if (choice == 4)
                {
                    Console.WriteLine("Write a new birthdate in dd/mm/yyyy: ");
                    var birthdate = Console.ReadLine();
                    var parsedBirthday = DateTime.Parse(birthdate);
                    
                    _petService.UpdateBirthDate(idToUpdate, parsedBirthday);
                    Console.WriteLine("\n");
                }

                if (choice == 5)
                {
                    Console.WriteLine("Write a new sold date in dd/mm/yyyy");
                    var soldDate = Console.ReadLine();
                    var parsedSoldDate = DateTime.Parse(soldDate);
                    
                    _petService.UpdateSoldDate(idToUpdate, parsedSoldDate);
                    Console.WriteLine("\n");
                }

                if (choice == 6)
                {
                    Console.WriteLine("Type a new color: ");
                    var color = Console.ReadLine();
                    
                    _petService.UpdatePetColor(idToUpdate, color);
                    Console.WriteLine("\n");
                }

                if (choice == 7)
                {
                    Console.WriteLine("Type a new price: ");
                    var priceString = Console.ReadLine();
                    double price;

                    if (double.TryParse(priceString, out price))
                    {
                        _petService.UpdatePetPrice(idToUpdate, price);
                    }
                    Console.WriteLine("\n");
                }
            }
        }
        
        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstants.Welcome);
        }

        private void ShowMainMenu()
        {
            Console.WriteLine(StringConstants.SelectShowAllPets);
            Console.WriteLine(StringConstants.SelectCreatePet);
            Console.WriteLine(StringConstants.SelectDeletePet);
            Console.WriteLine(StringConstants.SelectUpdatePet);
            Console.WriteLine(StringConstants.SelectSearchByType);
            Console.WriteLine(StringConstants.SelectShowMostExpensivePets);
            Console.WriteLine(StringConstants.SelectShowCheapestPets);
            Console.WriteLine(StringConstants.SelectExitApplication);

            Console.WriteLine("\n");
        }

        private int GetUpdatePetSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
        
        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
        
        private int GetPetTypeSelection()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }
    }
}