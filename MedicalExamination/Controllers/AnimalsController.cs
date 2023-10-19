using MedicalExamination.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using MedicalExamination.ViewModels;
using MedicalExamination.Models;

namespace MedicalExamination.Controllers
{
    public class AnimalsController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;
        AnimalsService service;

        public AnimalsController()
        {
            service = new AnimalsService();
        }


        public List<string[]> ShowAnimals(string filter, string sorting, int currentPage, int pageSize)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Animals/{filter}/{sorting}/{currentPage}/{pageSize}").Result;

            var result = JsonConvert.DeserializeObject<List<string[]>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
        public AnimalView ShowAnimalsCardToView(string currentAnimal)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Animals/CardView/{currentAnimal}").Result;

            var result = JsonConvert.DeserializeObject<AnimalView>(response.Content.ReadAsStringAsync().Result);

            return result;
        }


        public string[] ShowAnimalsCardToEdit(string choosedAnimal)
        {
        
            return new AnimalsService().GetAnimalsCardToEdit(choosedAnimal);
        }

        public void AddAnimal(AnimalView data)
        {
            var animalData = JsonConvert.SerializeObject(data);
            var content = (HttpContent)new StringContent(animalData, Encoding.UTF8, "application/json");

            var response = client.PostAsync($"ME/Animals", content).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                throw new InvalidOperationException("У вас нет доступа к этой операции!");
        }

        public void EditAnimal(string choosedAnimal, string[] animalData, List<string> Photos)
        {
            new AnimalsService().EditAnimal(choosedAnimal, animalData, Photos);
        }

        public void DeleteAnimal(string choosedAnimal)
        {
            new AnimalsService().DeleteAnimal(choosedAnimal);
        }

        public void ExportAnimalsToExcel(string filter, string sorting, string[] columnNames)
        {
            new AnimalsService().ExportAnimalsToExcel(filter, sorting, columnNames);
        }

        public List<Locality> GetLocalities()
        {
            HttpResponseMessage response = client.GetAsync($"ME/Localities/").Result;

            var result = JsonConvert.DeserializeObject<List<Locality>>(response.Content.ReadAsStringAsync().Result);

            return result;
        }
    }
}
