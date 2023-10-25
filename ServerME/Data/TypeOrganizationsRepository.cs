using ServerME.Models;

namespace ServerME.Data
{
    public class TypeOrganizationsRepository
    {
        public List<TypeOrganization> GetTypeOrganizationsForUser(Dictionary<string, string> privilege)
        {
            var privilegeOrg = privilege["Organization"];
            var typesPriv = privilegeOrg.Split(';')[1].Split(',').Select(e => int.Parse(e)).ToHashSet();
            List<TypeOrganization> types = new List<TypeOrganization>();
            foreach (var e in TestData.TypeOrganizations)
            {
                if (typesPriv.Contains(e.IdTypeOrganization))
                {
                    types.Add(e);
                }
            }
            return types;
        }
    }
}
