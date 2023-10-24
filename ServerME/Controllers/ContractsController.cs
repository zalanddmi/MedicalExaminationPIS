using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private MunicipalContractsService service = new MunicipalContractsService();  
        [HttpGet("Examination")]
        public ActionResult<List<MunicipalContract>> GetContractsAvailableUser()
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();
            
            return Ok(service.GetAvailableContracts(user));
        }

        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var contracts = service.GetMunicipalContracts(filter, sorting, currentPage, pageSize, user);
            return Ok(contracts);
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
