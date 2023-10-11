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
    public class OrganizationsService
    {
        private PrivilegeService service = new PrivilegeService();
        public OrganizationsService()
        {

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
            var gotOrganizations = new OrganizationsRepository().GetOrganizations(filter, sorting, privilege, currentPage, pageSize);
            var organizations = MapOrganizations(gotOrganizations);
            return organizations;
        }

        public string[] GetOrganizationCardToView(string choosedOrganization)
        {
            var organization = new OrganizationsRepository().GetOrganization(choosedOrganization);
            var organizationCardToView = MapOrganization(organization);
            return organizationCardToView;
        }

        public string[] GetOrganizationCardToEdit(string choosedOrganization)
        {
            var organization = new OrganizationsRepository().GetOrganization(choosedOrganization);
            var organizationCardToEdit = MapOrganization(organization);
            return organizationCardToEdit;
        }

        public void MakeOrganization(string[] organizationData, User user)
        {
            var resultCheck = new PrivilegeService().CheckUserForOrganization(user);
            if (resultCheck)
            {
                var typeOrganization = TestData.TypeOrganizations[int.Parse(organizationData[5]) - 1];
                var locality = TestData.Localities[int.Parse(organizationData[6]) - 1];
                var organization = new Organization(organizationData[0], organizationData[1], organizationData[2], organizationData[3],
                    organizationData[4] == "Юрлицо", typeOrganization, locality);
                new OrganizationsRepository().AddOrganization(organization);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void EditOrganization(string choosedOrganization, string[] organizationData)
        {
            var resultCheck = new PrivilegeService().CheckOrganizationForUser(choosedOrganization);
            if (resultCheck)
            {
                var typeOrganization = TestData.TypeOrganizations[int.Parse(organizationData[5]) - 1];
                var locality = TestData.Localities[int.Parse(organizationData[6]) - 1];
                var organization = new Organization(organizationData[0], organizationData[1], organizationData[2], organizationData[3],
                    organizationData[4] == "Юрлицо", typeOrganization, locality);
                new OrganizationsRepository().UpdateOrganization(choosedOrganization, organization);
            }
            else
            {
                //MessageBox.Show("Вы не можете редактировать эти данные");
            }
        }

        public void DeleteOrganization(string choosedOrganization)
        {
            var resultCheck = new PrivilegeService().CheckOrganizationForUser(choosedOrganization);
            if (resultCheck)
            {
                new OrganizationsRepository().DeleteOrganization(choosedOrganization);
            }
            else
            {
                //MessageBox.Show("Вы не можете удалить эти данные");
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
