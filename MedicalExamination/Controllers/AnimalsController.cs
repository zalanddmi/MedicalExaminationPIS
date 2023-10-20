using MedicalExamination.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedicalExamination.ViewModels;
using MedicalExamination.Models;
using System.IO;
using ClosedXML.Excel;


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
        }

        public void UpdateAnimal(AnimalView card)
        {
            var animalData = JsonConvert.SerializeObject(card);
            var content = (HttpContent)new StringContent(animalData, Encoding.UTF8, "application/json");

            var response = client.PutAsync($"ME/Animals", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void DeleteAnimal(int animalId)
        {
            var response = client.DeleteAsync($"ME/Animals/{animalId}").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public async void ExportAnimalsToExcel(string filter, string sorting, string[] columnNames)
        {
            HttpResponseMessage response = await client.GetAsync($"ME/Animals/{filter}/{sorting}");

            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                using (var file = File.Create(@"C:\Users\mk19\source\repos\MedicalExaminationPIS\MedicalExamination\Files\anima23l.xlsx"))
                {

                    stream.CopyTo(file);   
                }


            }
    
        }

        public List<Locality> GetLocalities()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Localities/").Result;

            var result = JsonConvert.DeserializeObject<List<Locality>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
