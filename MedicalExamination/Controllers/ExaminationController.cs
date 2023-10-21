using MedicalExamination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MedicalExamination.Models;
using MedicalExamination.ViewModels;

namespace MedicalExamination.Controllers
{
    class ExaminationController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;
        public List<MunicipalContract> GetContracts()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Contracts/Examination").Result;

            var result = JsonConvert.DeserializeObject<List<MunicipalContract>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
        public void AddExamination(ExaminationView examinationData)
        {
            var animalData = JsonConvert.SerializeObject(examinationData);
            var content = (HttpContent)new StringContent(animalData, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Examination", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }
    }
}
