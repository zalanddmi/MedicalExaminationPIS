using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public class PrivilegeRepository
    {
        public Dictionary<string, string> GetPrivilege(User user)
        {
            var role = user.Role;
            var privilegeData = TestData.Privileges.FirstOrDefault(priv => priv.Role == role);
            var privilege = privilegeData.Name;
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
            var privilegeData = TestData.Privileges.FirstOrDefault(priv => priv.Role == role);
            var privilege = privilegeData.Name;
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

        public bool GetResultCheckOrganizationForUser(User user, string choosedOrganization)
        {
            var organization = new OrganizationsRepository().GetOrganization(choosedOrganization);
            var typeOrganization = organization.TypeOrganization.IdTypeOrganization;
            var role = user.Role;
            var privilegeData = TestData.Privileges.FirstOrDefault(priv => priv.Role == role);
            var privilege = privilegeData.Name;
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
            var privilegeData = TestData.Privileges.FirstOrDefault(priv => priv.Role == role);
            var privilege = privilegeData.Name;
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
            var privilegeData = TestData.Privileges.FirstOrDefault(priv => priv.Role == role);
            var privilege = privilegeData.Name;
            if (privilege.ContainsKey("Examination"))
            {
                var opportunities = privilege["Examination"].Split(';');
                if (opportunities[1] == "All")
                {
                    return true;
                }
            }
            return false;
        }

        public bool GetResultCheckUserForMunicipalContract(User user)
        {
            var role = user.Role;
            var privilegeData = TestData.Privileges.FirstOrDefault(priv => priv.Role == role);
            var privilege = privilegeData.Name;
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

        public bool GetResultCheckMunicipalContractForUser(User user, string choosedMunicipalContract)
        {
            var privilege = GetPrivilege(user);
            var municipalContract = new MunicipalContractsRepository().GetMunicipalContract(choosedMunicipalContract);
            var municipality = TestData.Costs.Where(c => c.MunicipalContract.IdMunicipalContract == municipalContract.IdMunicipalContract).Select(c => c.Locality.Municipality.IdMunicipality);
            if (privilege.ContainsKey("MunicipalContract"))
            {
                var opportunities = privilege["MunicipalContract"].Split(';');
                if (opportunities[1] == "Mun")
                {
                    var mun = opportunities[1].Split('=');
                    if (municipality.Contains(int.Parse(mun[1])))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
