using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Controllers
{
    public class LoggingController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public List<string[]> ShowLogs(string filter, string sorting, int currentPage, int pageSize)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Log/{filter}/{sorting}/{currentPage}/{pageSize}").Result;

            var result = JsonConvert.DeserializeObject<List<string[]>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public void DeleteLogs(string logIds)
        {
            string url = "ME/Log";
            if (string.IsNullOrEmpty(logIds))
            {
                url += $"?logIds={logIds}";
            }
            var response = client.DeleteAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public async Task<byte[]> ExportLogsToExcel(string filter, string sorting)
        {
            HttpResponseMessage response = await client.GetAsync($"ME/Log/{filter}/{sorting}");

            var bytes = await response.Content.ReadAsByteArrayAsync();
            return bytes;
        }
    }
}
