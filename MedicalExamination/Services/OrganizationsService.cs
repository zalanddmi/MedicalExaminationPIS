﻿using System;
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
        public OrganizationsService()
        {

        }

        public List<string[]> MapOrganizations(Dictionary<int, Organization> gotOrganizations)
        {
            var organizations = new List<string[]>();
            foreach (var gotOrganization in gotOrganizations)
            {
                var organization = new List<string>();
                var key = gotOrganization.Key;
                var organizationData = gotOrganization.Value;
                organization.Add(key.ToString());
                organization.Add(organizationData.Name);
                organization.Add(organizationData.TaxIdNumber);
                organization.Add(organizationData.CodeReason);
                organization.Add(organizationData.Address);
                organization.Add(organizationData.TypeOrganization.Name);
                organization.Add(organizationData.IsJuridicalPerson ? "Юрлицо" : "ИП");
                organization.Add(organizationData.Locality.Name);
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

        public List<string[]> GetOrganizations()
        {
            var gotOrganizations = new OrganizationsRepository().GetOrganizations();
            var organizations = MapOrganizations(gotOrganizations);
            return organizations;
        }

        public string[] GetOrganizationCardToView(string choosedOrganization)
        {
            var organization = new OrganizationsRepository().GetOrganization(choosedOrganization);
            var organizationCardToView = MapOrganization(organization);
            return organizationCardToView;
        }
    }
}
