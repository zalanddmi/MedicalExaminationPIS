using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerME.Data;
using ServerME.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ServerME.ViewModels;
//using Excel = Microsoft.Office.Interop.Excel;

namespace ServerME.Services
{
    public class AnimalsService
    {
        PrivilegeService privilegeService;
        AnimalsRepository animalsRepository;
        LocalityRepository localityRepository;
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

        public AnimalView MapViewAnimal(Animal animal)
        {
            //получаем все фото
            var photos = new List<ViewModels.Image>();
            foreach (var path in animal.Photos)
            {
                if (path is null)
                    continue;
                photos.Add(new ViewModels.Image(path, File.ReadAllBytes(path)));
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
        public AnimalView GetAnimalsCardToView(string idAnimal)
        {
            var animal = animalsRepository.GetAnimal(idAnimal);
            var animalCardToView = MapViewAnimal(animal);
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

        /*public void ExportAnimalsToExcel(string filter, string sorting, string[] columnNames)
        {
            var animals = GetAnimals(filter, sorting, 1, int.MaxValue);
            ExportToExcel(animals, columnNames);
        }

        private void ExportToExcel(List<string[]> animals, string[] columnNames)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1] = columnNames[j];
            }
            for (int i = 0; i < animals.Count; i++)
            {
                for (int j = 0; j < animals[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = animals[i][j + 1];
                }
            }
            Excel.Range columns = worksheet.UsedRange.Columns;
            columns.AutoFit();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel файлы (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Сохранить файл Excel";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                workbook.SaveAs(saveFileDialog.FileName);
                excelApp.Visible = true;
            }
            worksheet = null;
            workbook.Close();
            excelApp.Quit();
        }*/
        public void MakeAnimal(AnimalView data, User user)
        {
            var resultCheck = new PrivilegeService().CheckUserForAnimal(user);
            if (resultCheck)
            {
                var animal = new Animal(data.RegNumber, data.Category, data.SexAnimal, 
                    data.YearBirthday, data.NumberElectronicChip, data.Name, SavePhotos(data.Photos), 
                    data.SignsAnimal, data.SignsOwner, data.Locality);
                new AnimalsRepository().AddAnimal(animal);
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
                var path = photo.SaveImage("Files");
                pathPhoto.Add(path);
            }
            return pathPhoto;
        }

        public void EditAnimal(string choosedAnimal, string[] animalData, List<string> Photos)
        {
            var resultCheck = new PrivilegeService().CheckUserForAnimal();
            if (resultCheck)
            {
                var locality = TestData.Localities[int.Parse(animalData[8]) - 1];
                var animal = new Animal(animalData[0], animalData[1], animalData[2], Convert.ToInt32(animalData[3]),
                    animalData[4], animalData[5], Photos, animalData[6], animalData[7], locality);
                new AnimalsRepository().UpdateAnimal(choosedAnimal, animal);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
