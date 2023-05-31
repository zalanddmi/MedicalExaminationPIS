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

        public bool CheckUserForOrganization()
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckUserForOrganization(user);
            return resultCheck;
        }

        public bool CheckOrganizationForUser(string choosedOrganization)
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckOrganizationForUser(user, choosedOrganization);
            return resultCheck;
        }
    }
}
