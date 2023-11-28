using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Models;
using ServerME.Enums;
using ServerME.Utils;
namespace ServerME.Data
{
    public class AnimalsRepository
    {
        private Utils.Logger<Animal> logger;
        public AnimalsRepository()
        {
            logger = new Utils.Logger<Animal>();
        }

        public List<Animal> GetAnimals(string filter, string sorting,
            Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var animals = GetAnimalsList(filter, sorting, privilege, currentPage, pageSize);

            return animals;
        }

        private List<Animal> GetAnimalsList(string filter, string sorting,
    Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var filterValues = filter.Split(';');
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);

            IQueryable<Animal> animalsQuery;

            using (var dbContext = new Context())
            {
                var priv = privilege["Animal"].Split(';');
                if (priv[0] == "All")
                {
                    animalsQuery = dbContext.Animals.Include(p => p.Locality);
                }
                else
                {
                    var mun = priv[0].Split('=');
                    animalsQuery = dbContext.Animals
                        .Include(p => p.Locality)
                        .Where(p => p.Locality.Municipality.IdMunicipality == int.Parse(mun[1]));
                }

                foreach (var fil in filterValues)
                {
                    var filArray = fil.Split('=');
                    animalsQuery = ApplyFilter(animalsQuery, filArray);
                }

                foreach (var sort in sortValues)
                {
                    var sortArray = sort.Split('=');                    
                    animalsQuery = ApplySorting(animalsQuery, sortArray);
                }

                return animalsQuery
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        public string GetStatus(int idAnimal)
        {
            using (var dbContext = new Context())
            {
                var examination = dbContext.Examinations
                    .Where(p=>p.Animal.IdAnimal== idAnimal && p.DateExamination > (DateTime.Now.AddMonths(-1)))
                    .OrderBy(p => p.DateExamination)
                    .LastOrDefault();
                if (examination is null)
                    return "Не проводилось";
                if (examination.EmergencyAssistance)
                    return "Требуется экстренная помощь";
                if (examination.Treatment != "не назначено")
                    return "Назначено лечение";
            }
            return "Не требуется лечение";
        }

        private IQueryable<Animal> ApplyFilter(IQueryable<Animal> animalsQuery, string[] filArray)
        {
            return filArray[0] switch
            {
                "RegNumber" => filArray[1] != " " ? animalsQuery.Where(ani => ani.RegNumber.Contains(filArray[1])) : animalsQuery,
                "Category" => filArray[1] != " " ? animalsQuery.Where(ani => ani.Category.Contains(filArray[1])) : animalsQuery,
                "SexAnimal" => filArray[1] != " " ? animalsQuery.Where(ani => ani.SexAnimal.Contains(filArray[1])) : animalsQuery,
                "YearBirthday" => filArray[1] != " " ? animalsQuery.Where(ani => ani.YearBirthday.ToString().Contains(filArray[1])) : animalsQuery,
                "NumberElectronicChip" => filArray[1] != " " ? animalsQuery.Where(ani => ani.NumberElectronicChip.Contains(filArray[1])) : animalsQuery,
                "Name" => filArray[1] != " " ? animalsQuery.Where(ani => ani.Name.Contains(filArray[1])) : animalsQuery,
                "SignsAnimal" => filArray[1] != " " ? animalsQuery.Where(ani => ani.SignsAnimal.Contains(filArray[1])) : animalsQuery,
                "SignsOwner" => filArray[1] != " " ? animalsQuery.Where(ani => ani.SignsOwner.Contains(filArray[1])) : animalsQuery,
                "Locality" => filArray[1] != " " ? animalsQuery.Where(ani => ani.Locality.Name.Contains(filArray[1])) : animalsQuery,
                _ => animalsQuery,
            };
        }

        private IQueryable<Animal> ApplySorting(IQueryable<Animal> animalsQuery, string[] sortArray)
        {
            var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
            return sortArray[0] switch
            {
                "RegNumber" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.RegNumber) : animalsQuery.OrderByDescending(ani => ani.RegNumber),
                "Category" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.Category) : animalsQuery.OrderByDescending(ani => ani.Category),
                "SexAnimal" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.SexAnimal) : animalsQuery.OrderByDescending(ani => ani.SexAnimal),
                "YearBirthday" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.YearBirthday) : animalsQuery.OrderByDescending(ani => ani.YearBirthday),
                "NumberElectronicChip" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.NumberElectronicChip) : animalsQuery.OrderByDescending(ani => ani.NumberElectronicChip),
                "Name" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.Name) : animalsQuery.OrderByDescending(ani => ani.Name),
                "SignsAnimal" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.SignsAnimal) : animalsQuery.OrderByDescending(ani => ani.SignsAnimal),
                "SignsOwner" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.SignsOwner) : animalsQuery.OrderByDescending(ani => ani.SignsOwner),
                "Locality" => sortDirection == SortDirection.Ascending ? animalsQuery.OrderBy(ani => ani.Locality.Name) : animalsQuery.OrderByDescending(ani => ani.Locality.Name),
                _ => animalsQuery,
            };
        }

        public Animal GetAnimal(int animalId)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Animals.Include(p => p.Locality.Municipality).First(p => p.IdAnimal == animalId);
            }
        }

        public void AddAnimal(User user, Animal animal)
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
                    logger.LogAdding(user, animal);
                    Console.WriteLine(String.Join("|", dbContext.Logs.ToList().Select(p => $"{p.Id} - {p.Operation}")));
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
        public void UpdateAnimal(User user, Animal animal)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var oldValue = dbContext.Animals.AsNoTracking().Include(p => p.Locality.Municipality).First(p => p.IdAnimal == animal.IdAnimal);
                    dbContext.Animals.Update(animal);
                    dbContext.SaveChanges();
                    logger.LogUpdating(user, oldValue, animal);
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

        public void DeleteAnimal(User user, int animalId)
        {
            using (var dbContext = new Context())
            {

                try
                {
                    dbContext.Animals.Where(p => p.IdAnimal == animalId).ExecuteDelete();
                    logger.LogRemoving(user, animalId);
                }
                catch (Exception)
                {
                    Console.WriteLine("Удаление карточки");
                    throw new InvalidOperationException("Удаление животного невозможно, " +
                        "так как животное имеет осмотры");
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
