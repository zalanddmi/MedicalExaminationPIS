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

        public List<Organization> GetOrganizations()
        {
            return TestData.Organizations;
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
    }
}
