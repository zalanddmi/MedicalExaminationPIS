using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using ServerME.Data;
using ServerME.Models;

namespace ServerME.Services
{
    public class OrganizationsService
    {
        private PrivilegeService service = new PrivilegeService();
        private OrganizationsRepository repository;
        public OrganizationsService()
        {
            repository = new OrganizationsRepository(); 
        }

        public List<string[]> MapOrganizations(List<Organization> gotOrganizations)
        {
            var organizations = new List<string[]>();
            foreach (var gotOrganization in gotOrganizations)
            {
                var organization = new List<string>
                {
                    gotOrganization.IdOrganization.ToString(),
                    gotOrganization.Name,
                    gotOrganization.TaxIdNumber,
                    gotOrganization.CodeReason,
                    gotOrganization.Address,
                    gotOrganization.TypeOrganization.Name,
                    gotOrganization.IsJuridicalPerson ? "Юрлицо" : "ИП",
                    gotOrganization.Locality.Name
                };
                organizations.Add(organization.ToArray());
            }
            return organizations;
        }

        public string[] MapOrganization(Organization organization)
        {
            var organizationList = new List<string>
            {
                organization.Name,
                organization.TaxIdNumber,
                organization.CodeReason,
                organization.Address,
                organization.TypeOrganization.Name,
                organization.IsJuridicalPerson ? "Юрлицо" : "ИП",
                organization.Locality.Name
            };
            return organizationList.ToArray();
        }

        public List<string[]> GetOrganizations(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = service.SetPrivilegeForUser(user);
            var gotOrganizations = repository.GetOrganizations(filter, sorting, privilege, currentPage, pageSize);
            var organizations = MapOrganizations(gotOrganizations);
            return organizations;
        }

        public Organization GetOrganizationCardToView(int organizationId)
        {
            var organization = repository.GetOrganization(organizationId);
            return organization;
        }
        public void MakeOrganization(Organization organization, User user)
        {
            var resultCheck = service.CheckUserForOrganization(user);
            if (resultCheck)
            {
                repository.AddOrganization(organization);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void EditOrganization(Organization organization, User user)
        {
            var resultCheck = service.CheckOrganizationForUser(organization.IdOrganization, user);
            if (resultCheck)
            {
                repository.UpdateOrganization(organization);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public byte[] GetExcelByteArrayFormat(string filter, string sorting, User user)
        {
            string[] columnNames = new string[] {"Название",
                "ИНН", "КПП", "Адрес регистрации", "Тип организиции",
                "ИП/Юрлицо", "Населенный пункт" };

            var animals = GetOrganizations(filter, sorting, 1, int.MaxValue, user);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var exPac = new ExcelPackage();
            var worksheet = exPac.Workbook.Worksheets.Add("organization");

            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1].Value = columnNames[j];
            }
            for (int i = 0; i < animals.Count; i++)
            {
                for (int j = 0; j < animals[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = animals[i][j + 1];
                }
            }

            worksheet.Cells.AutoFitColumns();
            return exPac.GetAsByteArray();
        }

        public void DeleteOrganization(int organizationId, User user)
        {
            var resultCheck = service.CheckOrganizationForUser(organizationId, user);
            if (resultCheck)
            {
                repository.DeleteOrganization(organizationId);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /*public void ExportOrganizationsToExcel(string filter, string sorting, string[] columnNames)
        {
            var organizations = GetOrganizations(filter, sorting, 1, int.MaxValue);
            ExportToExcel(organizations, columnNames);
        }

        private void ExportToExcel(List<string[]> organizations, string[] columnNames)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;
            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1] = columnNames[j];
            }
            for (int i = 0; i < organizations.Count; i++)
            {
                for (int j = 0; j < organizations[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = organizations[i][j + 1];
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
    }
}
