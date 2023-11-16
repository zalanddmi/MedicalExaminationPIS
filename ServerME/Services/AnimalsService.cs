using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerME.Data;
using ServerME.Models;
using ServerME.ViewModels;
using ServerME.Utils;

namespace ServerME.Services
{
    public class AnimalsService
    {
        PrivilegeService privilegeService;
        AnimalsRepository animalsRepository;
        LocalityRepository localityRepository;
        string directory = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName + "\\Files";
        public AnimalsService()
        {
            privilegeService = new PrivilegeService();
            animalsRepository = new AnimalsRepository();
            localityRepository = new LocalityRepository();
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

        public AnimalView MapViewAnimal(Animal animal)
        {
            //получаем все фото
            var photos = new List<ViewModels.Image>();
            foreach (var path in animal.Photos)
            {
                if (path is null)
                    continue;
                photos.Add(new ViewModels.Image(path, File.ReadAllBytes(directory + path)));
            }

            var animalView = new AnimalView
            (
                animal.IdAnimal,
                animal.RegNumber,
                animal.Category,
                animal.SexAnimal,
                animal.YearBirthday,
                animal.NumberElectronicChip,
                animal.Name,
                photos,
                animal.SignsAnimal,
                animal.SignsOwner,
                animal.Locality
            );
            return animalView;
        }
        public List<string[]> GetAnimals(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotAnimals = animalsRepository.GetAnimals(filter, sorting, privilege, currentPage, pageSize);
            var animals = MapAnimals(gotAnimals);
            return animals;
        }
        public AnimalView GetAnimalCard(int animalId)
        {
            var animal = animalsRepository.GetAnimal(animalId);
            var animalCardToView = MapViewAnimal(animal);
            return animalCardToView;
        }


        public void DeleteAnimal(int animalId, User user)
        {
            var resultCheck = privilegeService.CheckUserForAnimal(user);

            if (resultCheck)
            {
                animalsRepository.DeleteAnimal(animalId);
            }
            else
            {
                throw new InvalidOperationException("У вас нет прав, чтобы удалить!");
            }
        }


        public byte[] GetExcelByteArrayFormat(string filter, string sorting, User user)
        {
            string[] columnNames = new string[] {"Регистрационный номер", 
                "Категория", "Пол", "Год рождения", "Номер электронного чипа", 
                "Кличка", "Особенности животного", "Признаки владельца", "Населенный пункт" };

            var animals = GetAnimals(filter, sorting, 1, int.MaxValue, user);
            return ExcelConverter.GenerateExcelFile(animals, columnNames);
        }

        public void MakeAnimal(AnimalView data, User user)
        {
            var resultCheck = privilegeService.CheckUserForAnimal(user);
            if (resultCheck)
            {
                var animal = new Animal(data.RegNumber, data.Category, data.SexAnimal, 
                    data.YearBirthday, data.NumberElectronicChip, data.Name, SavePhotos(data.Photos), 
                    data.SignsAnimal, data.SignsOwner, data.Locality);
                animalsRepository.AddAnimal(animal);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private List<string> SavePhotos(List<ViewModels.Image> photos)
        {
            List<string> pathPhoto = new List<string>();
            foreach (var photo in photos)
            {
                //удаление фотки и сохранение старой
                var filePath = directory + photo.filePath; 
                if (photo.filePath != null && File.Exists(filePath))
                {
                    if (photo.data == null)
                    {
                        File.Delete(filePath);
                        continue;
                    }
                    pathPhoto.Add(photo.filePath);
                    continue;
                }
                if (photo.data == null)
                    continue;


                //сохранение новой фотки
                var fileName = $"\\photo{Guid.NewGuid()}.png";
                File.WriteAllBytes(directory + fileName, photo.data);


                pathPhoto.Add(fileName);
            }
            return pathPhoto;
        }

        public void UpdateAnimal(AnimalView card, User user)
        {
            var resultCheck = privilegeService.CheckUserForAnimal(user);
            if (resultCheck)
            {
                var animal = new Animal(card.IdAnimal, card.RegNumber, card.Category, card.SexAnimal,
                    card.YearBirthday, card.NumberElectronicChip, card.Name, SavePhotos(card.Photos),
                    card.SignsAnimal, card.SignsOwner, card.Locality);
                animalsRepository.UpdateAnimal(animal);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
