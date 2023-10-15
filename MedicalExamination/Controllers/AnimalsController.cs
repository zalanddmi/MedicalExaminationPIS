﻿using MedicalExamination.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
        public object[] ShowAnimalsCardToView(string currentAnimal)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Animals/CardView/{currentAnimal}").Result;

            var result = JsonConvert.DeserializeObject<object[]>(response.Content.ReadAsStringAsync().Result);

            return result;
        }


        public string[] ShowAnimalsCardToEdit(string choosedAnimal)
        {
        
            return new AnimalsService().GetAnimalsCardToEdit(choosedAnimal);
        }

        public void AddAnimal(object[] data)
        {
            var orgData = JsonConvert.SerializeObject(data);
            var content = (HttpContent)new StringContent(orgData, Encoding.UTF8, "application/json");

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
    }
}
