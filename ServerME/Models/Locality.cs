using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Models
{
    public class Locality
    {
        public int IdLocality { get; set; }
        public string Name { get; set; }
        public Municipality Municipality { get; set; }

        public Locality()
        {

        }
        public Locality(int idLocality, string name, Municipality municipality)
        {
            IdLocality = idLocality;
            Name = name;
            Municipality = municipality;
        }
    }
}
