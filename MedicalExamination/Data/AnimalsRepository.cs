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
        public List<Animal> GetAnimals(string filter, string sorting, int currentPage, int pageSize)
        {
            return TestData.Animals;   
        }

        public Animal GetAnimal(string choosedAnimal)
        {
            var idAnimal = int.Parse(choosedAnimal);
            var animal = TestData.Animals.First(ani => ani.IdAnimal == idAnimal);
            return animal;
        }
        public void DeleteAnimal(string choosedAnimal)
        {
            var idAnimal = int.Parse(choosedAnimal);
            TestData.Animals.RemoveAll(org => org.IdAnimal == idAnimal);
        }
    }
}
