﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MedicalExamination.ViewModels;
using MedicalExamination.Models;

namespace MedicalExamination.Controllers
{
    public class MunicipalContractsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public MunicipalContractsController()
        {

        }

        public List<string[]> ShowMunicipalContracts(string filter, string sorting, int currentPage, int pageSize)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Contracts/{filter}/{sorting}/{currentPage}/{pageSize}").Result;

            var result = JsonConvert.DeserializeObject<List<string[]>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public MunicipalContractView GetMunicipalContractCard(int municipalContractId)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Contracts/CardView/{municipalContractId}").Result;

            var result = JsonConvert.DeserializeObject<MunicipalContractView>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public List<Cost> GetCosts(int municipalContractId)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Contracts/CardView/Costs/{municipalContractId}").Result;

            var result = JsonConvert.DeserializeObject<List<Cost>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public void AddMunicipalContract(MunicipalContractView card)
        {
            var municipalContractData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(municipalContractData, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Contracts", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void UpdateMunicipalContract(MunicipalContractView card)
        {
            var municipalContractData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(municipalContractData, Encoding.UTF8, "application/json");

            var response = client.PutAsync($"ME/Contracts", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void DeleteMunicipalContract(int municipalContractId)
        {
            var response = client.DeleteAsync($"ME/Contracts/{municipalContractId}").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public async Task<byte[]> ExportMunicipalContractsToExcel(string filter, string sorting, string[] columnNames)
        {
            HttpResponseMessage response = await client.GetAsync($"ME/Contracts/{filter}/{sorting}");
            var bytes = await response.Content.ReadAsByteArrayAsync();
            return bytes;
        }

        public List<Organization> GetOrganizations()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/Contract").Result;
            var result = JsonConvert.DeserializeObject<List<Organization>>(response.Content.ReadAsStringAsync().Result);
            return result;
        }

        public List<Locality> GetLocalities()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Localities/Contract").Result;
            var result = JsonConvert.DeserializeObject<List<Locality>>(response.Content.ReadAsStringAsync().Result);
            return result;
        }
    }
}
