using EASV.PetShop.Security.Authentication;
using EASV.PetShop.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EASV.PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserAuthenticator _userAuthenticator;

        public LoginController(IUserAuthenticator userAuthenticator)
        {
            _userAuthenticator = userAuthenticator;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginInputDto loginInput)
        {
            string userToken;
            if (_userAuthenticator.Login(loginInput.Username, loginInput.Password, out userToken))
            {
                return Ok(new
                {
                    username = loginInput.Username,
                    token = userToken
                });
            }

            return Unauthorized("No access, bitch.");
        }
    }
}