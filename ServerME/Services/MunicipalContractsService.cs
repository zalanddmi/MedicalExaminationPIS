using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
//using System.Windows.Forms;
using ServerME.Data;
using ServerME.Models;
using ServerME.ViewModels;
//using Excel = Microsoft.Office.Interop.Excel;

namespace ServerME.Services
{
    class MunicipalContractsService
    {
        private MunicipalContractsRepository repository;
        private PrivilegeService privilegeService;
        string directory = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName + "\\Files";
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

        public MunicipalContractView MapViewMunicipalContract(MunicipalContract municipalContract, List<Cost> costs)
        {
            var scan = new List<Image>();
            foreach (var path in municipalContract.Scan)
            {
                if (path is null)
                    continue;
                scan.Add(new ViewModels.Image(path, File.ReadAllBytes(directory + path)));
            }
            var municipalContractView = new MunicipalContractView
            (
                municipalContract.IdMunicipalContract,
                municipalContract.Number,
                municipalContract.DateConclusion,
                municipalContract.DateAction,
                scan,
                municipalContract.Executor,
                municipalContract.Customer,
                costs
            );
            return municipalContractView;
        }


        public List<string[]> GetMunicipalContracts(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotMunicipalContracts = repository.GetMunicipalContracts(filter, sorting, privilege, currentPage, pageSize);
            var municipalcontracts = MapMunicipalContracts(gotMunicipalContracts);
            return municipalcontracts;
        }

        public MunicipalContractView GetMunicipalContractCard(int municipalContractId)
        {
            var municipalContract = repository.GetMunicipalContract(municipalContractId);
            var costs = GetCosts(municipalContractId);
            var municipalContractCard = MapViewMunicipalContract(municipalContract, costs);
            return municipalContractCard;
        }

        public List<Cost> GetCosts(int municipalContractId)
        {
            var costs = repository.GetCosts(municipalContractId);
            return costs;
        }

        public byte[] GetExcelByteArrayFormat(string filter, string sorting, User user)
        {
            string[] columnNames = new string[]
            {
                "Номер", "Дата заключения", "Дата действия", "Исполнитель", "Заказчик"
            };

            var contracts = GetMunicipalContracts(filter, sorting, 1, int.MaxValue, user);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var exPac = new ExcelPackage();
            var worksheet = exPac.Workbook.Worksheets.Add("contract");

            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1].Value = columnNames[j];
            }
            for (int i = 0; i < contracts.Count; i++)
            {
                for (int j = 0; j < contracts[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = contracts[i][j + 1];
                }
            }

            worksheet.Cells.AutoFitColumns();
            return exPac.GetAsByteArray();
        }

        public void MakeMunicipalContract(MunicipalContractView data, User user)
        {
            var resultCheck = privilegeService.CheckUserForMunicipalContract(user);
            if (resultCheck)
            {
                var municipalContract = new MunicipalContract(data.Number, data.DateConclusion, data.DateAction, 
                    SaveScan(data.Scan), data.Executor, data.Customer);
                repository.AddMunicipalContract(municipalContract, data.Costs);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void UpdateMunicipalContract(MunicipalContractView card, User user)
        {
            var resultCheck = privilegeService.CheckUserForMunicipalContract(user);
            if (resultCheck)
            {
                var municipalContract = new MunicipalContract(card.IdMunicipalContract, card.Number, card.DateConclusion,
                    card.DateAction, SaveScan(card.Scan), card.Executor, card.Customer);
                var costs = card.Costs;
                repository.UpdateMunicipalContract(municipalContract, costs);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void DeleteMunicipalContract(int municipalContractId, User user)
        {
            var resultCheck = privilegeService.CheckUserForMunicipalContract(user);

            if (resultCheck)
            {
                repository.DeleteMunicipalContract(municipalContractId);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private List<string> SaveScan(List<ViewModels.Image> scan)
        {
            List<string> pathScan = new List<string>();
            foreach (var sc in scan)
            {
                //удаление фотки и сохранение старой
                var filePath = directory + sc.filePath;
                if (sc.filePath != null && File.Exists(filePath))
                {
                    if (sc.data == null)
                    {
                        File.Delete(filePath);
                        continue;
                    }
                    pathScan.Add(sc.filePath);
                    continue;
                }
                if (sc.data == null)
                    continue;

                var fileName = $"\\scan{Guid.NewGuid()}.png";
                File.WriteAllBytes(directory + fileName, sc.data);
                pathScan.Add(fileName);
            }
            return pathScan;
        }
    }
}
