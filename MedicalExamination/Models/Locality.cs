using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Locality
    {
        public int IdLocality { get; set; }
        public string Name { get; set; }
        public Municipality Municipality { get; set; }

        public Locality(int idLocality, string name, Municipality municipality)
        {
            IdLocality = idLocality;
            Name = name;
            Municipality = municipality;
        }
    }

    public class Municipality
    {
        public int IdMunicipality { get; set; }
        public string Name { get; set; }

        public Municipality(int idMunicipality, string name)
        {
            IdMunicipality = idMunicipality;
            Name = name;
        }
    }

}
