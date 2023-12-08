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
        public ActionResult DeleteReport(int reportId)
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
        public ActionResult SaveReport([FromBody] Tuple<string, string, int, string> data)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                Console.WriteLine(data);
                service.SaveReport(data.Item1, data.Item2, data.Item3, data.Item4, user);
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

        [HttpGet("{reportId}")]
        public ActionResult<ReportView> GetReport(int reportId)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var report = service.GetReport(reportId, user);
            return Ok(report);
        }

        [HttpGet("Status")]
        public ActionResult<List<string[]>> GetStatusFromUser()
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var reports = service.GetStatusReport(user);
            return Ok(reports);
        }

    }
}
