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

        public virtual Dictionary<string, string> SetPrivilegeForUser()
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
        public bool CheckUserForAnimal()
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckUserForAnimal(user);
            return resultCheck;
        }

        public bool CheckUserForExamination()
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckUserForExamination(user);
            return resultCheck;
        }

        public bool CheckOrganizationForUser(string choosedOrganization)
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckOrganizationForUser(user, choosedOrganization);
            return resultCheck;
        }

        public bool CheckUserForMunicipalContract()
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckUserForMunicipalContract(user);
            return resultCheck;            
        }
        
        public bool CheckMunicipalContractForUser(string choosedMunicipalContract)
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckOrganizationForUser(user, choosedMunicipalContract);
            return resultCheck;
        }
    }
}
