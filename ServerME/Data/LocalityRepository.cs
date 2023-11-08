using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerME.Models;
using ServerME.Services;

namespace ServerME.Data
{
    public class LocalityRepository
    {
        public virtual List<Locality> GetLocalities(Dictionary<string, string> privilege)
        {
            List<Locality> localities = new List<Locality>();
            if (privilege.ContainsKey("Statistics"))
            {
                var priv = privilege["Statistics"].Split(';');
                var mun = priv[0].Split('=');
                using (var dbContext = new Context())
                {
                    localities = dbContext.Localities.Include(p => p.Municipality)
                        .Where(loc => loc.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
                }
            }
            return localities;
        }

        public List<Locality> GetLocalities()
        {
            using (var dbContext = new Context())
                return dbContext.Localities.Include(p => p.Municipality).ToList();
        }

        public Locality Get(int id) => TestData.Localities.First(loc => loc.IdLocality == id);

        public List<Locality> GetLocalitiesAvailableUser(Dictionary<string, string> privilege)
        {
            var privilegeOrg = privilege["Organization"];
            var priv = privilegeOrg.Split(';');
            if (priv[0] == "All")
            {
                using(var dbContext = new Context())
                {
                    return dbContext.Localities.Include(p => p.Municipality).ToList();
                }
            }
    
            // мб проблемы с доступом
            var munid = int.Parse(priv[0].Split('=')[1]);
            using (var dbContext = new Context())
            {
                return dbContext.Localities.Include(p => p.Municipality).Where(loc => loc.Municipality.IdMunicipality == munid).ToList();
            }          
        }
    }
}
