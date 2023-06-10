using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
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
    }
}
