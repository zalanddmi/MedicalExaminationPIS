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

        public virtual Dictionary<string, string> SetPrivilegeForUser(User user)
        {
            return repository.GetPrivilege(user);
        }

        public bool CheckUserForOrganization(User user)
        {
            
            var resultCheck = repository.GetResultCheckUserForOrganization(user);
            return resultCheck;
        }

        

        public bool CheckUserForAnimal(User user)
        {
            var resultCheck = repository.GetResultCheckUserForAnimal(user);
            return resultCheck;
        }

        public bool CheckUserForExamination(User user)
        {
            var resultCheck = repository.GetResultCheckUserForExamination(user);
            return resultCheck;
        }

        public bool CheckOrganizationForUser(int organizationId, User user)
        {
            var resultCheck = repository.GetResultCheckOrganizationForUser(user, organizationId);
            return resultCheck;
        }

        public bool CheckUserForMunicipalContract(User user)
        {
            var resultCheck = repository.GetResultCheckUserForMunicipalContract(user);
            return resultCheck;            
        }

        public bool CheckUserForLogs(User user)
        {
            var resultCheck = repository.GetResultCheckUserForLogs(user);
            return resultCheck;
        }
    }
}
