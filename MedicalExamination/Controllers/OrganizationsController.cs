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

        public void DeleteOrganization(string choosedOrganization)
        {
            new OrganizationsService().DeleteOrganization(choosedOrganization);
        }
    }
}
