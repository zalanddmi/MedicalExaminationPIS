using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerME.Models;
using ServerME.Services;
using Newtonsoft.Json;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private OrganizationsService service = new OrganizationsService();

        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            string? userStr = HttpContext.Session.GetString("user");
            if (userStr is null) return Unauthorized(); 
            
            var user = JsonConvert.DeserializeObject<User>(userStr);
            if (user is null) return Unauthorized();

            var orgs = service.GetOrganizations(filter, sorting, currentPage, pageSize, user);
            return Ok(orgs);
        }

        [HttpGet("CardView/{currentOrganization}")]
        public ActionResult<string[]> GetView(string currentOrganization)
        {
            return Ok(service.GetOrganizationCardToView(currentOrganization));
        }

        [HttpGet("CardEdit/{currentOrganization}")]
        public ActionResult<string[]> GetEdit(string currentOrganization)
        {
            return Ok(service.GetOrganizationCardToEdit(currentOrganization));
        }

        [HttpPost]
        public ActionResult AddOrganization(string[] orgData)
        {
            string? userStr = HttpContext.Session.GetString("user");
            if (userStr is null) return Unauthorized();

            var user = JsonConvert.DeserializeObject<User>(userStr);
            if (user is null) return Unauthorized();
           
            try
            {
                service.MakeOrganization(orgData, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
        }
    }
}
