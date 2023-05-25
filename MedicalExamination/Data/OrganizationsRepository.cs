using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public class OrganizationsRepository
    {
        public OrganizationsRepository()
        {

        }

        public List<Organization> GetOrganizations(string filter, string sorting, int currentPage, int pageSize)
        {
            var sortValues = sorting.Split(';');
            var sortColumn = sortValues[0];
            var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortValues[1]);
            var filterValues = filter.Split(',');
            var filteredOrganizations = filter != ""
                    ? TestData.Organizations
                    .Where(org => filterValues.Contains(org.Locality.Name) || filterValues.Contains(org.TypeOrganization.Name))
                    : TestData.Organizations;
            var sortedOrganizations = ApplySorting(filteredOrganizations, sortColumn, sortDirection); ;
            return sortedOrganizations
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Organization GetOrganization(string choosedOrganization)
        {
            var idOrganization = int.Parse(choosedOrganization);
            var organization = TestData.Organizations.First(org => org.IdOrganization == idOrganization);
            return organization;
        }

        public void AddOrganization(Organization organization)
        {
            var maxId = TestData.Organizations.Max(org => org.IdOrganization);
            organization.IdOrganization = maxId + 1;
            TestData.Organizations.Add(organization);
        }

        public void UpdateOrganization(string choosedOrganization, Organization organization)
        {
            var idOrganization = int.Parse(choosedOrganization);
            organization.IdOrganization = idOrganization;
            TestData.Organizations[idOrganization - 1] = organization;
        }

        public void DeleteOrganization(string choosedOrganization)
        {
            var idOrganization = int.Parse(choosedOrganization);
            TestData.Organizations.RemoveAll(org => org.IdOrganization == idOrganization);
        }

        private IEnumerable<Organization> ApplySorting(IEnumerable<Organization> filteredOrganizations, string sortColumn, SortDirection sortDirection)
        {
            switch (sortColumn)
            {
                case "NameOrg":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.Name)
                        : filteredOrganizations.OrderByDescending(org => org.Name);
                case "TaxIdNumber":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.TaxIdNumber)
                        : filteredOrganizations.OrderByDescending(org => org.TaxIdNumber);
                case "CodeReason":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.CodeReason)
                        : filteredOrganizations.OrderByDescending(org => org.CodeReason);
                case "Address":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.Address)
                        : filteredOrganizations.OrderByDescending(org => org.Address);
                case "TypeOrganization":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.TypeOrganization.Name)
                        : filteredOrganizations.OrderByDescending(org => org.TypeOrganization.Name);
                case "IsJuridicalPerson":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.IsJuridicalPerson)
                        : filteredOrganizations.OrderByDescending(org => org.IsJuridicalPerson);
                case "Locality":
                    return (sortDirection == SortDirection.Ascending)
                        ? filteredOrganizations.OrderBy(org => org.Locality.Name)
                        : filteredOrganizations.OrderByDescending(org => org.Locality.Name);
                default:
                    return filteredOrganizations;
            }
        }

        private enum SortDirection
        {
            Ascending,
            Descending
        }
    }
}
