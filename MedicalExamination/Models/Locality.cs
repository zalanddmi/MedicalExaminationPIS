using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Locality
    {
        public string Name;
        public Municipality Municipality;

        public Locality(string name, Municipality municipality)
        {
            Name = name;
            Municipality = municipality;
        }
    }

    public class Municipality
    {
        public string Name;

        public Municipality(string name)
        {
            Name = name;
        }
    }

}
