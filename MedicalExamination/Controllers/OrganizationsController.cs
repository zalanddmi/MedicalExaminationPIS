using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;
using Newtonsoft.Json;

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

        public string[] ShowOrganizationCardToView(string currentOrganization)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/CardView/{currentOrganization}").Result;
            
            var result = JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public string[] ShowOrganizationCardToEdit(string currentOrganization)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/CardEdit/{currentOrganization}").Result;

            var result = JsonConvert.DeserializeObject<string[]>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public void AddOrganization(string[] organizationData)
        {
            var orgData = JsonConvert.SerializeObject(organizationData);
            var content = (HttpContent)new StringContent(orgData, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Organizations", content).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void EditOrganization(string currentOrganization, string[] organizationData)
        {
            var request = new HttpRequestMessage(HttpMethod.Put,
                $"ME/Organizations?currentOrganization={currentOrganization}&orgData={organizationData}");

            var response = client.SendAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void DeleteOrganization(string currentOrganization)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"ME/Organizations/{currentOrganization}");

            var response = client.SendAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void ExportOrganizationsToExcel(string filter, string sorting, string[] columnNames)
        {
            new OrganizationsService().ExportOrganizationsToExcel(filter, sorting, columnNames);
        }
    }
}
