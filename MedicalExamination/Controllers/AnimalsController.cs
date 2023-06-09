﻿using MedicalExamination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Controllers
{
    public class AnimalsController
    {
        public List<string[]> ShowAnimals(string filter, string sorting, int currentPage, int pageSize)
        {
            return new AnimalsService().GetAnimals(filter, sorting, currentPage, pageSize);
        }

        public string[] ShowAnimalsCardToView(string choosedAnimal)
        {
            return new AnimalsService().GetAnimalsCardToView(choosedAnimal);
        }

        public string[] ShowAnimalsCardToEdit(string choosedAnimal)
        {
            return new AnimalsService().GetAnimalsCardToEdit(choosedAnimal);
        }

        public void AddAnimal(string[] animalnData, List<string> Photos)
        {
            new AnimalsService().MakeAnimal(animalnData, Photos);
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
