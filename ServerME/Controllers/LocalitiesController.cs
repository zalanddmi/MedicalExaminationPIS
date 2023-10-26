using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class LocalitiesController : ControllerBase
    {
        private LocalitiesService service = new LocalitiesService();

        [HttpGet]
        public ActionResult<List<Locality>> Get()
        {
            var localities = service.GetLocalities();
            return Ok(localities);
        }

        [HttpGet("Contract")]
        public ActionResult<List<Locality>> GetForContract()
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var localities = service.GetLocalitiesForContract(user);
            return Ok(localities);
        }





        private User? GetCurrentUser()
        {
            string? userStr = HttpContext.Session.GetString("user");
            if (userStr is null) return null;

            var user = JsonConvert.DeserializeObject<User>(userStr);
            if (user is null) return null;

            return user;
        }
    }
}
