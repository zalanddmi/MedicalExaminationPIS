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
    public class StatisticsController : ControllerBase
    {
        private StatisticsService statisticsService = new StatisticsService();
        [HttpGet("{from}/{to}")]
        public ActionResult<StatisticView> GetStatistics(string from, string to)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            StatisticView statisticView = statisticsService.GetStatistics(DateTime.Parse(from), DateTime.Parse(to), user);
            return Ok(JsonConvert.SerializeObject(statisticView));
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
