using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public class AuthorizationRepository
    {
        public List<User> GetUsers()
        {
            return TestData.Users;
        }
    }
}
