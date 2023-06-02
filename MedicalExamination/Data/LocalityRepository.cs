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
        public List<Locality> GetLocalities(Dictionary<string, string> privilege)
        {
            var priv = privilege["Statistics"].Split(';');
            var mun = priv[0].Split('=');
            var localities = TestData.Localities
                .Where(loc => loc.IdLocality == int.Parse(mun[1])).ToList();
            return localities;
        }
    }
}
