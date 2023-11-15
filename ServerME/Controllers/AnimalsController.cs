using ClosedXML.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;
using ServerME.ViewModels;
using System.Data;

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

        [HttpGet("CardView/{animalId}")]
        public ActionResult<AnimalView> GetView(int animalId)
        {
            return Ok(JsonConvert.SerializeObject(service.GetAnimalCard(animalId)));
        }



        //система боль мусо
        [HttpGet("{filter}/{sorting}")]
        public IActionResult GetExcel(string filter, string sorting)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var excel = service.GetExcelByteArrayFormat(filter, sorting, user);
            var file = File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "animal.xlsx");
            return file;
        }

    


        [HttpPost]
        public ActionResult AddAnimal(AnimalView animalCard)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.MakeAnimal(animalCard, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
            catch(ArgumentException error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpPut]
        public ActionResult UpdateAnimal(AnimalView animalCard)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.UpdateAnimal(animalCard, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
            catch (ArgumentException error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("{animalId}")]
        public ActionResult DeleteAnimal(int animalId)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.DeleteAnimal(animalId, user);
                return Ok();
            }
            catch (InvalidOperationException error)
            {
                return Conflict(error.Message);
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
