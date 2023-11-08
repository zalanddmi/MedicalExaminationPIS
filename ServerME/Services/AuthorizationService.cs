using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Data;
using ServerME.Models;

namespace ServerME.Services
{
    public class AuthorizationService
    {
        AuthorizationRepository repository = new AuthorizationRepository();
        public User? CheckAuthorization(string login, string password)
        {
            var users = repository.GetUsers();
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
