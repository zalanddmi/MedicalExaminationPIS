using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerME.Models;
using ServerME.Services;
using Newtonsoft.Json;

namespace ServerME.Controllers
{
    [ApiController]
    [Route("ME/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        [HttpGet("{login}/{password}")]
        public ActionResult<Dictionary<string, string>> Get(string login, string password)
        {
            User? user = new AuthorizationService().CheckAuthorization(login, password);
            if (user is null)
            {
                return Unauthorized();
            }
            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user));
            var privilege = new PrivilegeService().SetPrivilegeForUser(user);
            return Ok(privilege);
        }
    }
}
