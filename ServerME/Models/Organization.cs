﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Models
{
    public class Organization
    {
        public int? IdOrganization { get; set; }
        public string Name { get; set; }
        public string TaxIdNumber { get; set; }
        public string CodeReason { get; set; }
        public string Address { get; set; }
        public bool IsJuridicalPerson { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public Locality Locality { get; set; }

        [JsonIgnore]
        public List<MunicipalContract> ContractsExecutor { get; set; } = new();
        [JsonIgnore]
        public List<MunicipalContract> ContractsCustomer { get; set; } = new();

        [JsonIgnore]
        public List<User> Users { get; set; } = new();

        [JsonIgnore]
        public List<Examination> Examinations { get; set; } = new();

        public Organization()
        {

        }
        public Organization(string name, string taxIdNumber, string codeReason, string address, 
            bool isJuridicalPerson, TypeOrganization typeOrganization, Locality locality)
        {
            Name = name;
            TaxIdNumber = taxIdNumber;
            CodeReason = codeReason;
            Address = address;
            IsJuridicalPerson = isJuridicalPerson;
            TypeOrganization = typeOrganization;
            Locality = locality;
        }
    }
}
