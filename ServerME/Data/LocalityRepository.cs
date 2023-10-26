using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Models;

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
                localities = TestData.Localities
                    .Where(loc => loc.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
            }
            return localities;
        }

        public List<Locality> GetLocalities() => TestData.Localities;

        public List<Locality> GetLocalitiesForContract(Dictionary<string, string> privilege)
        {
            var mun = privilege["MunicipalContract"].Split(';')[1].Split('=');
            var localities = TestData.Localities
                .Where(loc => loc.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
            return localities;
        }

        public Locality Get(int id) => TestData.Localities.First(loc => loc.IdLocality == id);
    }
}
