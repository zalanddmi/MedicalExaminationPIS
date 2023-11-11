using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedicalExamination.ViewModels;
using MedicalExamination.Models;
using System.IO;
using ClosedXML.Excel;
using System.Threading.Tasks;

namespace MedicalExamination.Controllers
{
    public class AnimalsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public AnimalsController()
        {

        }

        public List<string[]> ShowAnimals(string filter, string sorting, int currentPage, int pageSize)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Animals/{filter}/{sorting}/{currentPage}/{pageSize}").Result;

            var result = JsonConvert.DeserializeObject<List<string[]>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public AnimalView GetAnimalCard(int animalId)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Animals/CardView/{animalId}").Result;

            var result = JsonConvert.DeserializeObject<AnimalView>(response.Content.ReadAsStringAsync().Result);

            return result;
        }

        public void AddAnimal(AnimalView card)
        {
            var animalData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(animalData, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Animals", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public void UpdateAnimal(AnimalView card)
        {
            var animalData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(animalData, Encoding.UTF8, "application/json");

            var response = client.PutAsync($"ME/Animals", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorMessage = response.Content.ReadAsStringAsync().Result;
                throw new ArgumentException(errorMessage);
            }
        }

        public void DeleteAnimal(int animalId)
        {
            var response = client.DeleteAsync($"ME/Animals/{animalId}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public async Task<byte[]> ExportAnimalsToExcel(string filter, string sorting)
        {
            HttpResponseMessage response = await client.GetAsync($"ME/Animals/{filter}/{sorting}");
            
            var bytes = await response.Content.ReadAsByteArrayAsync();
            return bytes;
        }

        public List<Locality> GetLocalities()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Localities/").Result;

            var result = JsonConvert.DeserializeObject<List<Locality>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
