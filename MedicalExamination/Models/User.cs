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

        public User(int idUser, string name, string post)
        {
            IdUser = idUser;
            Name = name;
            Post = post;
        }
    }
}
