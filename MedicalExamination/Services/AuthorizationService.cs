using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Data;
using MedicalExamination.Models;

namespace MedicalExamination.Services
{
    public class AuthorizationService
    {
        public bool CheckAuthorization(string login, string password)
        {
            var users = new AuthorizationRepository().GetUsers();
            foreach (var user in users)
            {
                if (user.Login == login && user.Password == password)
                {
                    UserSession.User = user;
                    return true;
                }
            }
            return false;
        }
    }
}
