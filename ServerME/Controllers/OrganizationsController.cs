﻿using Microsoft.AspNetCore.Http;
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
        private TypeOrganizationsService serviceTypeOrganization = new TypeOrganizationsService();

        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var orgs = service.GetOrganizations(filter, sorting, currentPage, pageSize, user);
            return Ok(orgs);
        }

        [HttpGet("CardView/{organizationId}")]
        public ActionResult<Organization> GetView(int organizationId)
        {
            return Ok(service.GetOrganizationCardToView(organizationId));
        }
        

        [HttpGet("TypeOrganization")]
        public ActionResult<List<TypeOrganization>> GetTypeOrganizations()
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var typeOrganizations = serviceTypeOrganization.GetTypeOrganizations(user);
            return Ok(typeOrganizations);
        }

        [HttpPost]
        public ActionResult AddOrganization(Organization orgData)
        {
            var user = GetCurrentUser();
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

        [HttpPut]
        public ActionResult EditOrganization(Organization orgData)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.EditOrganization(orgData, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
        }

        [HttpDelete]
        public ActionResult DeleteOrganization(int organizationId)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.DeleteOrganization(organizationId, user);
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
