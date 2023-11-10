using ServerME.Models;

namespace ServerME.Data
{
    public class TypeOrganizationsRepository
    {
        public List<TypeOrganization> GetTypeOrganizationsForUser(Dictionary<string, string> privilege)
        {
            var privilegeOrg = privilege["Organization"];
            if (privilegeOrg.Split(';')[1] == "None")
            {
                return new List<TypeOrganization>();
            }
            var typesPriv = privilegeOrg.Split(';')[1]
                .Split(',').Select(e => int.Parse(e)).ToHashSet();
            List<TypeOrganization> types = new List<TypeOrganization>();
            var typeOrg = new List<TypeOrganization>();
            using (var dbContext = new Context())
            {
                typeOrg = dbContext.TypeOrganizations.ToList();
            }
            foreach (var e in typeOrg)
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
