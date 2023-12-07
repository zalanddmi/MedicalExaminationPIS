using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;
using ServerME.ViewModels;

namespace ServerME.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private ReportService service = new();

        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var orgs = service.GetReports(filter, sorting, currentPage, pageSize, user);
            return Ok(orgs);
        }
        private User? GetCurrentUser()
        {
            string? userStr = HttpContext.Session.GetString("user");
            if (userStr is null) return null;

            var user = JsonConvert.DeserializeObject<User>(userStr);
            if (user is null) return null;

            return user;
        }

        [HttpDelete("{reportId}")]
        public ActionResult DeleteAnimal(int reportId)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.DeleteReport(reportId, user);
                return Ok();
            }
            catch (InvalidOperationException error)
            {
                return Conflict(error.Message);
            }
        }

        [HttpPost]
        public ActionResult SaveReport(string from, string to, string status)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.SaveReport(from, to, status, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateReport(ReportView reportCard)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.UpdateReport(reportCard, user);
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

    }
}
