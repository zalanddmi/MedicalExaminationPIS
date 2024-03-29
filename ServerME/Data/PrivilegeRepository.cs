﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Models;

namespace ServerME.Data
{
    public class PrivilegeRepository
    {
        OrganizationsRepository organizationsRepository;
        public PrivilegeRepository()
        {
            organizationsRepository = new OrganizationsRepository();
        }
        public Dictionary<string, string> GetPrivilege(User user)
        {
            var role = user.Role;
            var privilege = role.Privileges;
            var privKey = privilege.Keys.ToArray();
            for (int i = 0; i < privilege.Count; i++)
            {
                var opportunities = privilege[privKey[i]].Split(';');
                for (int j = 0; j < opportunities.Length; j++)
                {
                    if (opportunities[j] == "Org")
                    {
                        opportunities[j] += "=" + user.Organization.IdOrganization.ToString();
                    }
                    else if (opportunities[j] == "Mun")
                    {
                        opportunities[j] += "=" + user.Organization.Locality.Municipality.IdMunicipality.ToString();
                    }
                }
                privilege[privKey[i]] = opportunities[0] + ";" + opportunities[1];
            }
            return privilege;
        }

        public bool GetResultCheckUserForOrganization(User user)
        {
            var role = user.Role;
            var privilege = role.Privileges;
            if (privilege.ContainsKey("Organization"))
            {
                var opportunities = privilege["Organization"].Split(';');
                if (opportunities[1] != "None")
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetResultCheckUserForReport(User user, string status)
        {
            var role = user.Role;

            switch (role.Name)
            {
                case "Оператор ОМСУ":
                    return new List<string>() { "Черновик", "Согласование у исполнителя", "Доработка"}.Contains(status);
                case "Куратор приюта":
                    return new List<string>() { "Согласование у исполнителя", "Согласован у исполнителя" }.Contains(status);
                case "Подписант приюта":
                    return new List<string>() { "Согласован у исполнителя", "Утвержден у исполнителя" }.Contains(status);
                case "Куратор ОМСУ":
                    return new List<string>() { "Утвержден у исполнителя", "Согласован ОМСУ" }.Contains(status);
                default:
                    return new List<string>() { "Нет статуса" }.Contains(status);
            }
        }

        public bool GetResultCheckUserForLogs(User user)
        {
            var role = user.Role;
            var privilage = role.Privileges;
            return privilage.ContainsKey("Admin");
        }

        public bool GetResultCheckOrganizationForUser(User user, int organizationId)
        {
            var organization = organizationsRepository.GetOrganization(organizationId);
            var typeOrganization = organization.TypeOrganization.IdTypeOrganization;
            var role = user.Role;
            var privilege = role.Privileges;
            if (privilege.ContainsKey("Organization"))
            {
                var opportunities = privilege["Organization"].Split(';');
                if (opportunities[1] != "None")
                {
                    var types = opportunities[1].Split(',');
                    foreach (var type in types)
                    {
                        if (int.Parse(type) == typeOrganization)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        public bool GetResultCheckUserForAnimal(User user)
        {
            var role = user.Role;
            var privilege = role.Privileges;
            if (privilege.ContainsKey("Animal"))
            {
                var opportunities = privilege["Animal"].Split(';');
                if (opportunities[1] == "All")
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetResultCheckUserForExamination(User user)
        {
            var role = user.Role;
            var privilege = role.Privileges;
            if (privilege.ContainsKey("Examination"))
            {
                var opportunities = privilege["Examination"].Split(';');
                if (opportunities[0] == "All")
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetResultCheckUserForMunicipalContract(User user)
        {
            var role = user.Role;
            var privilege = role.Privileges;
            if (privilege.ContainsKey("MunicipalContract"))
            {
                var opportunities = privilege["MunicipalContract"].Split(';');
                if (opportunities[1] != "None")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
