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
                        opportunities[j] = user.Organization.IdOrganization.ToString();
                    }
                    else if (opportunities[j] == "Mun")
                    {
                        opportunities[j] = user.Organization.Locality.Municipality.IdMunicipality.ToString();
                    }
                }
                privilege[privKey[i]] = opportunities[0] + ";" + opportunities[1];
            }
            return privilege;
        }
    }
}
