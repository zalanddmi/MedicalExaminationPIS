using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Models;

namespace ServerME.Data
{
    public class AuthorizationRepository
    {
        public List<User> GetUsers()
        {
            return TestData.Users;
        }
    }
}
