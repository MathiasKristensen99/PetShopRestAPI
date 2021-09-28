using System;
using System.Collections.Generic;
using EASV.PetShop.Core.IServices;
using EASV.PetShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> ReadAllUsers()
        {
            try
            {
                return Ok(_userService.ReadAllUsers());
            }
            catch (Exception e)
            {
                return StatusCode(500, "Du har fucked op");
            }
        }
    }
}