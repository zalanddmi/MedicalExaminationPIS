using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Data;
using MedicalExamination.Models;

namespace MedicalExamination.Services
{
    public class AnimalsService
    {
        public AnimalsService()
        {

        }

        public List<string[]> MapAnimals(List<Animal> gotAnimals)
        {
            var animals = new List<string[]>();
            foreach (var gotAnimal in gotAnimals)
            {
                var animal = new List<string>
                {
                    gotAnimal.IdAnimal.ToString(),
                    gotAnimal.RegNumber,
                    gotAnimal.Category,
                    gotAnimal.SexAnimal,
                    gotAnimal.YearBirthday.ToString(),
                    gotAnimal.NumberElectronicChip,
                    gotAnimal.Name,
                    gotAnimal.SignsAnimal,
                    gotAnimal.SignsOwner,
                    gotAnimal.Locality.Name
                };
                animals.Add(animal.ToArray());
            }
            return animals;
        }

        public string[] MapAnimal(Animal animal)
        {
            var animalList = new List<string>
            {
                    animal.RegNumber,
                    animal.Category,
                    animal.SexAnimal,
                    animal.YearBirthday.ToString(),
                    animal.NumberElectronicChip,
                    animal.Name,
                    animal.SignsAnimal,
                    animal.SignsOwner,
                    animal.Locality.Name,
                    string.Join(";",animal.Photos)
            };
            return animalList.ToArray();
        }

        public List<string[]> GetAnimals(string filter, string sorting, int currentPage, int pageSize)
        {
            var gotAnimals = new AnimalsRepository().GetAnimals(filter, sorting, currentPage, pageSize);
            var animals = MapAnimals(gotAnimals);
            return animals;
        }
        public string[] GetAnimalsCardToView(string choosedAnimal)
        {
            var animal = new AnimalsRepository().GetAnimal(choosedAnimal);
            var animalCardToView = MapAnimal(animal);
            return animalCardToView;
        }

        public string[] GetAnimalsCardToEdit(string choosedAnimal)
        {
            var animal = new AnimalsRepository().GetAnimal(choosedAnimal);
            var animalCardToEdit = MapAnimal(animal);
            return animalCardToEdit;
        }

        public void DeleteAnimal(string choosedAnimal)
        {
            new AnimalsRepository().DeleteAnimal(choosedAnimal);
        }
    }
}
