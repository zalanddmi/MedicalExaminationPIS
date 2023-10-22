using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Post { get; set; }
        public Role Role { get; set; }
        public string Login { get; set; }
        public string Password { get; private set; }
        public Organization Organization { get; set; }

        public User()
        {

        }
        public User(string name, string post, Role role, string login, string password, Organization organization)
        {
            Name = name;
            Post = post;
            Role = role;
            Login = login;
            Password = password;
            Organization = organization;
        }
        public User(int idUser, string name, string post, Role role, string login, string password, Organization organization)
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
