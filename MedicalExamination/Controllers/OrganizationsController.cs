using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;

namespace MedicalExamination.Controllers
{
    public class OrganizationsController
    {
        public List<string[]> ShowOrganizations()
        {
            return new OrganizationsService().GetOrganizations();
        }

        public string[] ShowOrganizationCardToView(string choosedOrganization)
        {
            return new OrganizationsService().GetOrganizationCardToView(choosedOrganization);
        }

        public string[] ShowOrganizationCardToEdit(string choosedOrganization)
        {
            return new OrganizationsService().GetOrganizationCardToEdit(choosedOrganization);
        }

        public void AddOrganization(string[] organizationData)
        {
            new OrganizationsService().MakeOrganization(organizationData);
        }

        public void EditOrganization(string choosedOrganization, string[] organizationData)
        {
            new OrganizationsService().EditOrganization(choosedOrganization, organizationData);
        }

        public void DeleteOrganization(string choosedOrganization)
        {
            new OrganizationsService().DeleteOrganization(choosedOrganization);
        }
    }
}
