using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        StatisticsService statisticsService = new StatisticsService();
        [HttpGet("{from}/{to}")]
        public ActionResult<Statistics> GetStatistics(DateTime from, DateTime to)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            return statisticsService.GetStatistics(from, to, user);
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
