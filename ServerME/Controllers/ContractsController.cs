﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServerME.Models;
using ServerME.Services;
using ServerME.ViewModels;
using System.Data;

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
            var result = service.GetAvailableContracts(user);
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet("{filter}/{sorting}/{currentPage}/{pageSize}")]
        public ActionResult<List<string[]>> Get(string filter, string sorting, int currentPage, int pageSize)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var contracts = service.GetMunicipalContracts(filter, sorting, currentPage, pageSize, user);
            return Ok(contracts);
        }

        [HttpGet("CardView/{municipalContractId}")]
        public ActionResult<MunicipalContractView> GetView(int municipalContractId)
        {
            return Ok(JsonConvert.SerializeObject(service.GetMunicipalContractCard(municipalContractId)));
        }

        [HttpGet("CardView/Costs/{municipalContractId}")]
        public ActionResult<List<Cost>> GetCosts(int municipalContractId)
        {
            return Ok(JsonConvert.SerializeObject(service.GetCosts(municipalContractId)));
        }

        [HttpGet("{filter}/{sorting}")]
        public IActionResult GetExcel(string filter, string sorting)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            var excel = service.GetExcelByteArrayFormat(filter, sorting, user);
            var file = File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "contract.xlsx");
            return file;
        }

        [HttpPost]
        public ActionResult AddMunicipalContract(MunicipalContractView municipalContractCard)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.MakeMunicipalContract(municipalContractCard, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
        }

        [HttpPut]
        public ActionResult UpdateMunicipalContract(MunicipalContractView municipalContractCard)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.UpdateMunicipalContract(municipalContractCard, user);
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return StatusCode(403);
            }
        }

        [HttpDelete("{municipalContractId}")]
        public ActionResult DeleteMunicipalContract(int municipalContractId)
        {
            var user = GetCurrentUser();
            if (user is null) return Unauthorized();

            try
            {
                service.DeleteMunicipalContract(municipalContractId, user);
                return Ok();
            }
            catch (InvalidOperationException error)
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
