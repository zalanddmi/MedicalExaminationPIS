using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class User
    {
        public string Name;
        public string Post;

        public User(string name, string post)
        {
            Name = name;
            Post = post;
        }
    }
}
