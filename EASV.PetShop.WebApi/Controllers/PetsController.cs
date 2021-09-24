using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using EASV.PetShop.Domain.Models;
using EASV.PetShop.WebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
        public ActionResult<Pet> Create([FromBody] PostPetDto dto)
        {
            var petFromDto = new Pet
            {
                Name = dto.Name,
                Color = dto.Name,
                BirthDate = dto.BirthDate,
                SoldDate = dto.SoldDate,
                Price = dto.Price,
                Owner = new Owner
                {
                    Id = dto.OwnerId
                },
                Insurance = new Insurance
                {
                    Id = dto.InsuranceId
                },
                PetType = new PetType
                {
                    Id = dto.PetTypeId
                }
            };

            try
            {
                var newPet = _petService.CreatePet(petFromDto);
                return Created($"https://localhost:5001/api/pets/{newPet.Id}",
                    newPet);
            }
            catch (ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
        }

        [HttpGet]
        public ActionResult<List<Pet>> GetAllPets()
        {
            return Ok(_petService.ReadAllPets());
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id)
        {
            return Ok(_petService.GetById(id));
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
