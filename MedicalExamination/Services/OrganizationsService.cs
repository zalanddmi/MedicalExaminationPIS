using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Data;
using MedicalExamination.Models;

namespace MedicalExamination.Services
{
    public class OrganizationsService
    {
        public Dictionary<int, Organization> GettedOrganizations = new Dictionary<int, Organization>();
        public List<string[]> Organizations = new List<string[]>();

        public OrganizationsService()
        {
            GettedOrganizations = new OrganizationsRepository().GetOrganizations();
            MapOrganizations();
        }

        public void MapOrganizations()
        {
            foreach (var gettedOrganization in GettedOrganizations)
            {
                var organization = new List<string>();
                var key = gettedOrganization.Key;
                var organizationData = gettedOrganization.Value;
                organization.Add(key.ToString());
                organization.Add(organizationData.Name);
                organization.Add(organizationData.TaxIdNumber);
                organization.Add(organizationData.CodeReason);
                organization.Add(organizationData.Address);
                organization.Add(organizationData.TypeOrganization.Name);
                organization.Add(organizationData.IsJuridicalPerson ? "Юрлицо" : "ИП");
                organization.Add(organizationData.Locality.Name);
                Organizations.Add(organization.ToArray());
            }
        }

        public List<string[]> GetOrganizations()
        {
            return Organizations;
        }
    }
}
