﻿using ServerME.Models;
using ServerME.Data;

namespace ServerME.Services
{
    public class LocalitiesService
    {
        private LocalityRepository repository;
        private PrivilegeService privilegeService;

        public LocalitiesService()
        {
            repository = new LocalityRepository();
            privilegeService = new PrivilegeService();
        }

        public List<Locality> GetLocalities() => repository.GetLocalities(); 

        public List<Locality> GetLocalitiesForContract(User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            var localities = repository.GetLocalitiesForContract(privilege);
            return localities;
        }

        public List<Locality> GetLocalitiesForOrganization(User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            return repository.GetLocalitiesAvailableUser(privilege);
        }
    }
}
