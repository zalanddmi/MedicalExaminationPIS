using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private AnimalsService service = new AnimalsService();

        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var orgs = service.GetAnimals(filter, sorting, currentPage, pageSize, user);
            return Ok(orgs);
        }

        [HttpGet("CardView/{idAnimal}")]
        public ActionResult<object[]> GetView(string idAnimal)
        {
            return Ok(service.GetAnimalsCardToView(idAnimal));
        }

        [HttpGet("CardEdit/{currentAnimal}")]
        public ActionResult<string[]> GetEdit(string currentAnimal)
        {
            return Ok(service.GetAnimalsCardToEdit(currentAnimal));
        }

        [HttpPost]
        public ActionResult AddAnimal(object[] animalData)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.MakeAnimal(animalData, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
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
