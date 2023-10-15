using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.Windows.Forms;
using ServerME.Data;
using ServerME.Models;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
//using Excel = Microsoft.Office.Interop.Excel;

namespace ServerME.Services
{
    public class AnimalsService
    {
        PrivilegeService privilegeService;
        AnimalsRepository animalsRepository;
        public AnimalsService()
        {
            privilegeService = new PrivilegeService();
            animalsRepository = new AnimalsRepository();
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
        public object[] MapObjectAnimal(Animal animal)
        {
            //получаем все фото
            List<byte[]> photos = new List<byte[]>();
            foreach (var path in animal.Photos)
            {
                if (path is null)  
                    continue;
                photos.Add(File.ReadAllBytes(path));
            }

            var animalObjArray = new object[]
            {
                animal.IdAnimal,
                animal.RegNumber,
                animal.Category,
                animal.SexAnimal,
                animal.YearBirthday.ToString(),
                animal.NumberElectronicChip,
                animal.Name,
                animal.SignsAnimal,
                animal.SignsOwner,
                animal.Locality.Name,
                photos
            };
            return animalObjArray;
        }

        public List<string[]> GetAnimals(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotAnimals = new AnimalsRepository().GetAnimals(filter, sorting, privilege, currentPage, pageSize);
            var animals = MapAnimals(gotAnimals);
            return animals;
        }
        public object[] GetAnimalsCardToView(string idAnimal)
        {
            var animal = animalsRepository.GetAnimal(idAnimal);
            var animalCardToView = MapObjectAnimal(animal);
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
        public void MakeAnimal(string[] animalData, List<string> Photos)
        {
            var resultCheck = new PrivilegeService().CheckUserForAnimal();
            if (resultCheck)
            {
                var locality = TestData.Localities[int.Parse(animalData[8]) - 1];
                var animal = new Animal(animalData[0], animalData[1], animalData[2], Convert.ToInt32(animalData[3]),
                    animalData[4], animalData[5], Photos, animalData[6], animalData[7], locality);
                new AnimalsRepository().AddAnimal(animal);
            }
            else
            {
                //MessageBox.Show("Вы не можете добавлять эти данные");
            }
        }
        public void MakeAnimal(object[] data, User user)
        {
            var resultCheck = new PrivilegeService().CheckUserForAnimal(user);
            if (resultCheck)
            {
                var locality = TestData.Localities[Convert.ToInt32(data[8]) - 1];
                var list = JsonConvert.DeserializeObject<List<byte[]>>(data[9].ToString());
                List<string> Photos = SavePhotos(list);
                var animal = new Animal(data[0].ToString(), data[1].ToString(), 
                    data[2].ToString(), Convert.ToInt32(data[3]),
                    data[4].ToString(), data[5].ToString(), Photos, data[6].ToString(), data[7].ToString(), locality);
                new AnimalsRepository().AddAnimal(animal);
            }
            else
            {
                //MessageBox.Show("Вы не можете добавлять эти данные");
            }
        }

        private List<string> SavePhotos(List<byte[]> photos)
        {
            List<string> pathPhoto = new List<string>();

            foreach (var photo in photos)
            {
                var stream = new MemoryStream(photo);
                var currentPhoto = Image.FromStream(stream);
                var path = $"Files/photo_{DateTime.Now.ToString()}_.png";
                currentPhoto.Save(path, ImageFormat.Png);
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
                //MessageBox.Show("Вы не можете редактировать эти данные");
            }
        }
    }
}
