using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;
using MedicalExamination.Models;
using System.Net.Http;
using Newtonsoft.Json;
using MedicalExamination.ViewModels;

namespace MedicalExamination.Controllers
{
    public class StatisticsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public StatisticView GetStatistics(string from, string to)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Statistics/{from}/{to}").Result;

            var result = JsonConvert.DeserializeObject<StatisticView>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
