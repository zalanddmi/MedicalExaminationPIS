using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;
using ServerME.ViewModels;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private ExaminationService service = new ExaminationService();

        [HttpPost]
        public ActionResult AddExamination(ExaminationView examinationData)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.MakeExamination(examinationData, user);
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
