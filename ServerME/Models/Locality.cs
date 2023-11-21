using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
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
        public Locality(string name, Municipality municipality)
        {
            Name = name;
            Municipality = municipality;
        }
        public Locality(int idLocality, string name, Municipality municipality)
        {
            IdLocality = idLocality;
            Name = name;
            Municipality = municipality;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj is Locality objLocality)
            {
                return IdLocality.Equals(objLocality.IdLocality) && Name.Equals(objLocality.Name)
                    && Municipality.Equals(objLocality.Municipality);
            }
            return false;
        }
    }
}
