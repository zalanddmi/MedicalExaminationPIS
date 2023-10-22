using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Models
{
    public class Role
    {
        public int IdRole { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Privileges { get; set; }

        public Role()
        {

        }
        public Role(string role, Dictionary<string, string> name)
        {
            Name = role;
            Privileges = name;
        }
        public Role(int idRole, string name, Dictionary<string, string> privileges)
        {
            IdRole = idRole;
            Name = name;
            Privileges = privileges;
        }
    }
}
