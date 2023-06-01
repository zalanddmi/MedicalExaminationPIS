using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Data;
using MedicalExamination.Models;
using Excel = Microsoft.Office.Interop.Excel;

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
            var privilege = new PrivilegeService().SetPrivilegeForUser();
            var gotAnimals = new AnimalsRepository().GetAnimals(filter, sorting, privilege, currentPage, pageSize);
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

        public void ExportAnimalsToExcel(string filter, string sorting, string[] columnNames)
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
        }
    }
}
