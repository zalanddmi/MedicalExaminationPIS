using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Data;
using ServerME.Models;

namespace ServerME.Services
{
    public class PrivilegeService
    {
        private PrivilegeRepository repository;

        public PrivilegeService()
        {
            repository = new PrivilegeRepository();
        }

        public virtual Dictionary<string, string> SetPrivilegeForUser()
        {
            var user = UserSession.User;
            return new PrivilegeRepository().GetPrivilege(user);
        }
        public virtual Dictionary<string, string> SetPrivilegeForUser(User user)
        {
            return new PrivilegeRepository().GetPrivilege(user);
        }

        public bool CheckUserForOrganization(User user)
        {
            
            var resultCheck = new PrivilegeRepository().GetResultCheckUserForOrganization(user);
            return resultCheck;
        }

        public bool CheckUserForAnimal(User user)
        {
            var resultCheck = repository.GetResultCheckUserForAnimal(user);
            return resultCheck;
        }

        public bool CheckUserForExamination()
        {
            var user = UserSession.User;
            var resultCheck = new PrivilegeRepository().GetResultCheckUserForExamination(user);
            return resultCheck;
        }

        public bool CheckOrganizationForUser(string choosedOrganization, User user)
        {
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
            var resultCheck = new PrivilegeRepository().GetResultCheckMunicipalContractForUser(user, choosedMunicipalContract);
            return resultCheck;
        }
    }
}
