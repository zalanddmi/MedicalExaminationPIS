using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Data;
using MedicalExamination.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace MedicalExamination.Services
{
    public class OrganizationsService
    {
        private List<string[]> organizations;
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

        public List<string[]> GetOrganizations(string filter, string sorting, int currentPage, int pageSize)
        {
            var gotOrganizations = new OrganizationsRepository().GetOrganizations(filter, sorting, currentPage, pageSize);
            organizations = MapOrganizations(gotOrganizations);
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

        public void MakeOrganization(string[] organizationData)
        {
            var typeOrganization = TestData.TypeOrganizations[int.Parse(organizationData[5]) - 1];
            var locality = TestData.Localities[int.Parse(organizationData[6]) - 1];
            var organization = new Organization(organizationData[0], organizationData[1], organizationData[2], organizationData[3],
                organizationData[4] == "Юрлицо", typeOrganization, locality);
            new OrganizationsRepository().AddOrganization(organization);
        }

        public void EditOrganization(string choosedOrganization, string[] organizationData)
        {
            var typeOrganization = TestData.TypeOrganizations[int.Parse(organizationData[5]) - 1];
            var locality = TestData.Localities[int.Parse(organizationData[6]) - 1];
            var organization = new Organization(organizationData[0], organizationData[1], organizationData[2], organizationData[3],
                organizationData[4] == "Юрлицо", typeOrganization, locality);
            new OrganizationsRepository().UpdateOrganization(choosedOrganization, organization);
        }

        public void DeleteOrganization(string choosedOrganization)
        {
            new OrganizationsRepository().DeleteOrganization(choosedOrganization);
        }

        public void ExportToExcel()
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;
            for (int i = 0; i < organizations.Count; i++)
            {
                for (int j = 0; j < organizations[i].Length - 1; j++)
                {
                    worksheet.Cells[i + 1, j + 1] = organizations[i][j + 1];
                }
            }
            workbook.SaveAs("путь_к_файлу.xlsx");
            workbook.Close();
            excel.Quit();
        }
    }
}
