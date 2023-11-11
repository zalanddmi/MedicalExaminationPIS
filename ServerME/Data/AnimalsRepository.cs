using Microsoft.EntityFrameworkCore;
using Npgsql;
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
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);
            var filterValues = filter.Split(';');
            var animals = new List<Animal>();
            var priv = privilege["Animal"].Split(';');
            if (priv[0] == "All")
            {
                using (var dbContext = new Context())
                {
                    animals = dbContext.Animals.Include(p => p.Locality).ToList();
                }
            }
            else
            {
                var mun = priv[0].Split('=');
                using (var dbContext = new Context())
                {
                    animals = dbContext.Animals.Include(p => p.Locality).Where(p => p.Locality.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
                }
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

        public Animal GetAnimal(int animalId)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Animals.Include(p => p.Locality.Municipality).First(p => p.IdAnimal == animalId);
            }
        }

        public void AddAnimal(Animal animal)
        {
            Console.WriteLine("Начало добавления");
            using (var dbContext = new Context())
            {
                try
                {
                    animal.Locality = dbContext.Localities
                        .Include(p => p.Municipality)
                        .First(p => p.IdLocality == animal.Locality.IdLocality);
                    dbContext.Animals.Add(animal);
                    Console.WriteLine("Добавление");
                    dbContext.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    var postEx = e.InnerException as PostgresException;
                    var errorColumn = postEx.ConstraintName.Split('_').Last();
                    errorColumn = ErrorMessage(errorColumn);
                    throw new ArgumentException(errorColumn);
                }
            }
            Console.WriteLine("Конец добавления");
        }
        public void UpdateAnimal(Animal animal)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    dbContext.Animals.Update(animal);
                    dbContext.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    var postEx = e.InnerException as PostgresException;
                    var errorColumn = postEx.ConstraintName.Split('_').Last();
                    errorColumn = ErrorMessage(errorColumn);
                    throw new ArgumentException(errorColumn);
                }
            }
        }

        public void DeleteAnimal(int animalId)
        {
            using (var dbContext = new Context())
            {
                var animal = dbContext.Animals.FirstOrDefault(ani => ani.IdAnimal == animalId);
                if (animal != null)
                {
                    dbContext.Animals.Remove(animal);
                    dbContext.SaveChanges();
                }
            }
        }
        private string ErrorMessage(string errorColumn)
        {
            switch (errorColumn)
            {
                case "RegNumber":
                    errorColumn = "Животное с таким регистрационным номером существует!";
                    break;
                case "NumberElectronicChip":
                    errorColumn = "Животное с таким номером электронного чипа существует!";
                    break;
                default:
                    break;
            }
            return errorColumn;
        }
    }

}
