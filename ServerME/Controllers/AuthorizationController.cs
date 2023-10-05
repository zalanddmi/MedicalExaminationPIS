using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerME.Models;
using ServerME.Services;
namespace ServerME.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet("{login}/{password}")]
        public ActionResult<User> Get(string login, string password)
        {
            User? user = new AuthorizationService().CheckAuthorization(login, password);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
