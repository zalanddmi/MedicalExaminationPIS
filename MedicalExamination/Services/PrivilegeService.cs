using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Data;
using MedicalExamination.Models;

namespace MedicalExamination.Services
{
    public class PrivilegeService
    {
        public PrivilegeService()
        {

        }

        public Dictionary<string, string> SetPrivilegeForUser()
        {
            var user = UserSession.User;
            return new PrivilegeRepository().GetPrivilege(user);
        }
    }
}
