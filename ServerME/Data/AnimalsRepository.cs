using ServerME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Data
{
    public class AnimalsRepository
    {
        public AnimalsRepository()
        {

        } 
        public List<Animal> GetAnimals(string filter, string sorting,
            Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            //return TestData.Animals;
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);
            var filterValues = filter.Split(';');
            var animals = new List<Animal>();
            var priv = privilege["Animal"].Split(';');
            if (priv[0] == "All")
            {
                animals = TestData.Animals;
            }
            else
            {
                var mun = priv[0].Split('=');
                animals = TestData.Animals
                     .Where(ani => ani.Locality.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
            }
            IEnumerable<Animal> filteredAnimals = animals;
            foreach (var fil in filterValues)
            {
                var filArray = fil.Split('=');
                filteredAnimals = filArray[0] == "RegNumber" && filArray[1] != " "
                    ? filteredAnimals.Where(ani => ani.RegNumber.Contains(filArray[1]))
                    : filteredAnimals;
                filteredAnimals = filArray[0] == "Category" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.Category.Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "SexAnimal" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.SexAnimal.Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "YearBirthday" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.YearBirthday.ToString().Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "NumberElectronicChip" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.NumberElectronicChip.Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "Name" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.Name.Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "SignsAnimal" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.SignsAnimal.Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "SignsOwner" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.SignsOwner.Contains(filArray[1]))
                   : filteredAnimals;
                filteredAnimals = filArray[0] == "Locality" && filArray[1] != " "
                   ? filteredAnimals.Where(ani => ani.Locality.Name.Contains(filArray[1]))
                   : filteredAnimals;

            }
            var sortedAnimals = ApplySorting(filteredAnimals, sortValues);
            return sortedAnimals
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private IEnumerable<Animal> ApplySorting(IEnumerable<Animal> filteredAnimals, string[] sortValues)
        {
            List<Animal> sortedAnimals = new List<Animal>();
            foreach (var sort in sortValues)
            {
                var sortArray = sort.Split('=');
                var sortColumn = sortArray[0];
                var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
                switch (sortColumn)
                {
                    case "RegNumber":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.RegNumber).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.RegNumber).ToList();
                        break;
                    case "Category":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.Category).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.Category).ToList();
                        break;
                    case "SexAnimal":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.SexAnimal).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.SexAnimal).ToList();
                        break;
                    case "YearBirthday":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.YearBirthday).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.YearBirthday).ToList();
                        break;
                    case "NumberElectronicChip":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.NumberElectronicChip).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.NumberElectronicChip).ToList();
                        break;
                    case "Name":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.Name).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.Name).ToList();
                        break;
                    case "SignsAnimal":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.SignsAnimal).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.SignsAnimal).ToList();
                        break;
                    case "SignsOwner":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.SignsOwner).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.SignsOwner).ToList();
                        break;
                    case "Locality":
                        sortedAnimals = (sortDirection == SortDirection.Ascending)
                            ? filteredAnimals.OrderBy(ani => ani.Locality).ToList()
                            : filteredAnimals.OrderByDescending(ani => ani.Locality).ToList();
                        break;
                    default:
                        sortedAnimals = filteredAnimals.ToList();
                        break;
                }
            }
            return sortedAnimals;
        }

        private enum SortDirection
        {
            Ascending,
            Descending
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
            TestData.Animals.RemoveAll(ani => ani.IdAnimal == idAnimal);
        }
        public void UpdateAnimal(string choosedAnimal, Animal animal)
        {
            var idAnimal = int.Parse(choosedAnimal);
            animal.IdAnimal = idAnimal;
            TestData.Animals[idAnimal - 1] = animal;
        }
        public void AddAnimal(Animal animal)
        {
            var maxId = TestData.Animals.Max(ani => ani.IdAnimal);
            animal.IdAnimal = maxId + 1;
            TestData.Animals.Add(animal);
        }
    }

}
