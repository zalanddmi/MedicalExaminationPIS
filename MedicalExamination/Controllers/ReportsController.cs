using MedicalExamination.Models;
using MedicalExamination.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Controllers
{

    public class ReportsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public ReportsController()
        {

        }

        public List<string[]> ShowReports(string filter, string sorting, int currentPage, int pageSize)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Reports/{filter}/{sorting}/{currentPage}/{pageSize}").Result;

            var result = JsonConvert.DeserializeObject<List<string[]>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public ReportView GetReportCard(int reportId)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Reports/{reportId}").Result;

            var result = JsonConvert.DeserializeObject<ReportView>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public void SaveReport(string from, string to, int organizationId, string status)
        {
            var data = JsonConvert.SerializeObject(Tuple.Create(from, to, organizationId, status));
            var content = (HttpContent)new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Reports", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public void UpdateReport(ReportView card)
        {
            var data = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(data, Encoding.UTF8, "application/json");

            var response = client.PutAsync($"ME/Reports", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public void DeleteReport(int reportId)
        {
            var response = client.DeleteAsync($"ME/Reports/{reportId}").Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public StatisticView GetStatisticsForOrganization(string from, string to, int organizationId)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Statistics/{from}/{to}/{organizationId}").Result;

            var result = JsonConvert.DeserializeObject<StatisticView>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public List<string> GetStatusForUser()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Reports/Status").Result;

            var result = JsonConvert.DeserializeObject<List<string>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
        public List<Organization> GetOrganizations()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Organizations/Report").Result;

            var result = JsonConvert.DeserializeObject<List<Organization>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
        public async Task<byte[]> ExportReportsToExcel(string filter, string sorting)
        {
            HttpResponseMessage response = await client.GetAsync($"ME/reports/{filter}/{sorting}");

            var bytes = await response.Content.ReadAsByteArrayAsync();
            return bytes;
        }
    }
}
