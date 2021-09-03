using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        private readonly IPetTypeService _petTypeService;

        public PetsController(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }

        [HttpPost]
        public void Create(Pet pet)
        {
            _petService.CreatePet(pet);
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAllPets()
        {
            return Ok(_petService.GetAllPets());
        }

        [HttpDelete]
        public void DeletePet(int id)
        {
            _petService.DeletePet(id);
        }

        [HttpPatch]
        public void UpdatePetName(int id, string name)
        {
            _petService.UpdatePetName(id, name);
        }
    }
}
