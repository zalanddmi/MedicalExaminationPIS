using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private LogService service = new LogService();
        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                var logs = service.GetLogs(filter, sorting, currentPage, pageSize, user);
                return Ok(logs);
            }
            catch (Exception error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpDelete("{logsId}")]
        public ActionResult DeleteLogs(string logsId)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var logsIdArray = logsId.Split(",").Select(id => int.Parse(id));
            try
            {
                service.DeleteLogs(logsIdArray, user);
                return Ok();
            }
            catch (InvalidOperationException error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpGet("{filter}/{sorting}")]
        public IActionResult GetExcel(string filter, string sorting)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                var excel = service.GetExcelByteArrayFormat(filter, sorting, user);
                var file = File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "animal.xlsx");
                return file;
            }
            catch (Exception error)
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
