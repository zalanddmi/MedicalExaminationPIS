using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using ServerME.Data;
using ServerME.Models;
//using Excel = Microsoft.Office.Interop.Excel;

namespace ServerME.Services
{
    class MunicipalContractsService
    {
        private MunicipalContractsRepository repository;
        private PrivilegeService privilegeService;
        public MunicipalContractsService()
        {
            repository = new MunicipalContractsRepository();  
            privilegeService = new PrivilegeService();  
        }

        public List<MunicipalContract> GetAvailableContracts(User user)
        {
            return repository.GetContractsForOrganization(user.Organization);
        }
        public List<string[]> MapMunicipalContracts(List<MunicipalContract> gotMunicipalContracts)
        {
            var municipalcontracts = new List<string[]>();
            foreach (var gotMunicipalContract in gotMunicipalContracts)
            {
                var municipalcontract = new List<string>
                {
                    gotMunicipalContract.IdMunicipalContract.ToString(),
                    gotMunicipalContract.Number,
                    gotMunicipalContract.DateConclusion.ToShortDateString(),
                    gotMunicipalContract.DateAction.ToShortDateString(),
                    gotMunicipalContract.Executor.Name,
                    gotMunicipalContract.Customer.Name,                   
                };
                municipalcontracts.Add(municipalcontract.ToArray());
            }
            return municipalcontracts;
        }

        public string[] MapMunicipalContract(MunicipalContract municipalcontract)
        {
            var municipalcontractList = new List<string>
            {
                    municipalcontract.Number,
                    municipalcontract.DateConclusion.ToShortDateString(),
                    municipalcontract.DateAction.ToShortDateString(),
                    municipalcontract.Executor.Name,
                    municipalcontract.Customer.Name,                   
                    string.Join(";",municipalcontract.Scan)
            };
            return municipalcontractList.ToArray();
        }


        public List<string[]> GetMunicipalContracts(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotMunicipalContracts = repository.GetMunicipalContracts(filter, sorting, privilege, currentPage, pageSize);
            var municipalcontracts = MapMunicipalContracts(gotMunicipalContracts);
            return municipalcontracts;
        }
        public string[] GetMunicipalContractCardToView(string choosedMunicipalConatract)
        {
            var municipalcontract = new MunicipalContractsRepository().GetMunicipalContract(choosedMunicipalConatract);
            var municipalcontractCardToView = MapMunicipalContract(municipalcontract);
            return municipalcontractCardToView;
        }
        public string[] GetMunicipalContractCardToEdit(string choosedMunicipalContract)
        {
            var municipalcontract = new MunicipalContractsRepository().GetMunicipalContract(choosedMunicipalContract);
            var municipalcontractCardToEdit = MapMunicipalContract(municipalcontract);
            return municipalcontractCardToEdit;
        }
        public void DeleteMunicipalContract(string choosedMunicipalContract)
        {
            var resultCheck = new PrivilegeService().CheckMunicipalContractForUser(choosedMunicipalContract);
            if (resultCheck)
            {
                new MunicipalContractsRepository().DeleteMunicipalContract(choosedMunicipalContract);
            }
            else
            {
                //MessageBox.Show("Вы не можете удалить эти данные");
            }
        }
        /*private void ExportToExcel(List<string[]> municipalcontracts, string[] columnNames)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1] = columnNames[j];
            }
            for (int i = 0; i < municipalcontracts.Count; i++)
            {
                for (int j = 0; j < municipalcontracts[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = municipalcontracts[i][j + 1];
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
        public void ExportMunicipalContractsToExcel(string filter, string sorting, string[] columnNames)
        {
            var municipalcontracts = GetMunicipalContracts(filter, sorting, 1, int.MaxValue);
            ExportToExcel(municipalcontracts, columnNames);
        }*/

        public void MakeMunicipalContract(string[] municipalcontractData, List<string> Photos)
        {
            var resultCheck = new PrivilegeService().CheckUserForMunicipalContract();
            if (resultCheck)
            {
               var executor = TestData.Organizations[int.Parse(municipalcontractData[4]) - 1];
               var customer = TestData.Organizations[int.Parse(municipalcontractData[5]) - 1];
               var municipalcontract = new MunicipalContract(municipalcontractData[0], DateTime.Parse(municipalcontractData[1]), DateTime.Parse(municipalcontractData[2]), Photos,
                   executor, customer);
               new MunicipalContractsRepository().AddMunicipalContract(municipalcontract);
            }
            else
            {
                //MessageBox.Show("Вы не можете добавлять эти данные");
            }        
        }

        public void EditMunicipalContract(string choosedMunicipalContract, string[] municipalcontractData, List<string> Photos) 
        {
            var resultCheck = new PrivilegeService().CheckUserForMunicipalContract();
            if (resultCheck)
            {

                var executor = TestData.Organizations[int.Parse(municipalcontractData[4]) - 1];
                var customer = TestData.Organizations[int.Parse(municipalcontractData[5]) - 1];
                var municipalcontract = new MunicipalContract(municipalcontractData[0], DateTime.Parse(municipalcontractData[1]), DateTime.Parse(municipalcontractData[2]), Photos,
                    executor, customer);
                new MunicipalContractsRepository().UpdateMunicipalContract(choosedMunicipalContract,municipalcontract);
            }
            else
            {
                //MessageBox.Show("Вы не можете редактировать эти данные");
            }
        }
    }
}
