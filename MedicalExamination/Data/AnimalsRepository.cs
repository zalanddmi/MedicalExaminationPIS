using MedicalExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Data
{
    public class AnimalsRepository
    {
        public AnimalsRepository()
        {

        } 
        public List<Animal> GetAnimals()
        {
            return TestData.Animals;   
        }

        public Animal GetAnimal(string choosedAnimal)
        {
            var idAnimal = int.Parse(choosedAnimal);
            var animal = TestData.Animals.First(ani => ani.IdAnimal == idAnimal);
            return animal;
        }
    }
}
