using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Organization
    {
        public string Name;
        public string TaxIdNumber;
        public string CodeReason;
        public string Address;
        public bool IsJuridicalPerson;
        public TypeOrganization TypeOrganization;

        public Organization(string name, string taxIdNumber, string codeReason, string address, 
            bool isJuridicalPerson, TypeOrganization typeOrganization)
        {
            Name = name;
            TaxIdNumber = taxIdNumber;
            CodeReason = codeReason;
            Address = address;
            IsJuridicalPerson = isJuridicalPerson;
            TypeOrganization = typeOrganization;
        }
    }

    public class TypeOrganization
    {
        public string Name;

        public TypeOrganization(string name)
        {
            Name = name;
        }
    }
}
