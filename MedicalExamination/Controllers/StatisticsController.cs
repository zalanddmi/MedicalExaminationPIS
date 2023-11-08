using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;
using MedicalExamination.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace MedicalExamination.Controllers
{
    public class StatisticsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public Statistics GetStatistics(DateTime from, DateTime to)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Statistics/{from}/{to}").Result;

            var result = JsonConvert.DeserializeObject<Statistics>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
