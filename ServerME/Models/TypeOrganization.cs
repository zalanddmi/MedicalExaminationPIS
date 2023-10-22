using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ServerME.Models
{
    public class TypeOrganization
    {
        public int IdTypeOrganization { get; set; }
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
