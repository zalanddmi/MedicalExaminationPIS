﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MedicalExamination.Models;

namespace MedicalExamination.Controllers
{
    public class OrganizationsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public List<string[]> ShowOrganizations(string filter, string sorting, int currentPage, int pageSize)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/{filter}/{sorting}/{currentPage}/{pageSize}").Result;

            var result = JsonConvert.DeserializeObject<List<string[]>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public Organization ShowOrganizationCardToView(int organizationId)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/CardView/{organizationId}").Result;
            
            var result = JsonConvert.DeserializeObject<Organization>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public void AddOrganization(Organization card)
        {
            var orgData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(orgData, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Organizations", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public void UpdateOrganization(Organization card)
        {
            var orgData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(orgData, Encoding.UTF8, "application/json");

            var response = client.PutAsync($"ME/Organizations", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public void DeleteOrganization(int organizationId)
        {
            var response = client.DeleteAsync($"ME/Organizations/{organizationId}").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public List<Locality> GetLocalities()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Localities/ForOrganization").Result;

            var result = JsonConvert.DeserializeObject<List<Locality>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public List<TypeOrganization> GetTypeOrganizations()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/TypeOrganization").Result;

            var result = JsonConvert.DeserializeObject<List<TypeOrganization>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public async Task<byte[]> ExportOrganizationsToExcelAsync(string filter, string sorting)
        {
            HttpResponseMessage response = await client.GetAsync($"ME/Organizations/{filter}/{sorting}");

            var bytes = await response.Content.ReadAsByteArrayAsync();

            return bytes;
        }
    }
}
