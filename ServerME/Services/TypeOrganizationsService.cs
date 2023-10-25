using ServerME.Models;
using ServerME.Data;

namespace ServerME.Services
{
    public class TypeOrganizationsService
    {
        private TypeOrganizationsRepository repository;
        public PrivilegeService privilegeService;
        public TypeOrganizationsService()
        {
            repository = new TypeOrganizationsRepository();
            privilegeService = new PrivilegeService();
        }

        public List<TypeOrganization> GetTypeOrganizations(User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);

            return repository.GetTypeOrganizationsForUser(privilege);
        }
    }
}
