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
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public void Create(Owner owner)
        {
            _ownerService.CreateOwner(owner);
        }

        [HttpGet]
        public ActionResult<List<Owner>> GetAllPets()
        {
            return Ok(_ownerService.GetAllOwners());
        }

        [HttpDelete]
        public void DeleteOwner(int id)
        {
            _ownerService.DeleteOwner(id);
        }

        [HttpPatch]
        public void UpdateOwnerName(int id, string name)
        {
            _ownerService.UpdateOwnerName(id, name);
        }
    }
}