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
    }
}
