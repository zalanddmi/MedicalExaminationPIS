using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; }
        public Organization Organization { get; set; }

        public User(int idUser, string name, string post, string role, string login, string password, Organization organization)
        {
            IdUser = idUser;
            Name = name;
            Post = post;
            Role = role;
            Login = login;
            Password = password;
            Organization = organization;
        }
    }
}
