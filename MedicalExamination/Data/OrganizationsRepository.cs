﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public class OrganizationsRepository
    {
        public Dictionary<int, Organization> Organizations = new Dictionary<int, Organization>();

        public OrganizationsRepository()
        {
            Organizations = TestData.Organizations;
        }

        public Dictionary<int, Organization> GetOrganizations()
        {
            return Organizations;
        }

        public Organization GetOrganization(string choosedOrganization)
        {
            var idOrganization = int.Parse(choosedOrganization);
            var organization = Organizations[idOrganization];
            return organization;
        }

        public void DeleteOrganization(string choosedOrganization)
        {
            var idOrganization = int.Parse(choosedOrganization);
            TestData.Organizations.Remove(idOrganization);
        }
    }
}
