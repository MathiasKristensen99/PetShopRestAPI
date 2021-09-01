using System;
using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.DataAccess;
using EASV.PetShop.Domain.IRepositories;
using EASV.PetShop.Domain.Models;
using EASV.PetShop.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EASV.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetTypeRepository, PetTypeRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetTypeService, PetTypeService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            
            IPetRepository repo = new PetRepository();
            IPetTypeRepository petTypeRepository = new PetTypeRepository();
            IPetService service = new PetService(repo);
            IPetTypeService petTypeService = new PetTypeService(petTypeRepository);
            
            Menu menu = new Menu(service, petTypeService);
            menu.Start();
        }
    }
}