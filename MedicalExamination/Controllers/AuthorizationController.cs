using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;

namespace MedicalExamination.Controllers
{
    public class AuthorizationController
    {
        public bool GetResultCheckAuthorization(string login, string password)
        {
            return new AuthorizationService().CheckAuthorization(login, password); 
        }
    }
}
