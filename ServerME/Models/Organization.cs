﻿using Microsoft.EntityFrameworkCore;
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
        [Key]
        public int IdOrganization { get; set; }
        public string Name { get; set; }
        public string TaxIdNumber { get; set; }
        public string CodeReason { get; set; }
        public string Address { get; set; }
        public bool IsJuridicalPerson { get; set; }
        public TypeOrganization TypeOrganization { get; set; }
        public Locality Locality { get; set; }

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

    [Index("Name", IsUnique = true)]
    public class TypeOrganization
    {
        [Key]
        public int IdTypeOrganization { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public TypeOrganization()
        {

        }
        public TypeOrganization(int idTypeOrganization, string name)
        {
            IdTypeOrganization = idTypeOrganization;
            Name = name;
        }
    }
}
