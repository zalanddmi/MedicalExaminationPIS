using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Controllers
{
    [Route("ME/[controller]")]
    [ApiController]
    public class LocalitiesController : ControllerBase
    {
        private LocalitiesService service = new LocalitiesService();

        [HttpGet]
        public ActionResult<List<Locality>> Get()
        {
            var localities = service.GetLocalities();
            return Ok(localities);
        }
    }
}
