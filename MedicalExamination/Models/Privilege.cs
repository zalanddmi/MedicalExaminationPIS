using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Privilege
    {
        public string Role { get; set; }
        public Dictionary<string, string> Name { get; set; }

        public Privilege(string role, Dictionary<string, string> name)
        {
            Role = role;
            Name = name;
        }
        
    }
}
