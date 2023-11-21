using System.ComponentModel.DataAnnotations;

namespace ServerME.Models
{
    public class Municipality
    {
        public int IdMunicipality { get; set; }
        public string Name { get; set; }

        public Municipality()
        {

        }
        public Municipality(string name)
        {
            Name = name;
        }
        public Municipality(int idMunicipality, string name)
        {
            IdMunicipality = idMunicipality;
            Name = name;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj is Municipality objMunicipality)
            {
                return IdMunicipality.Equals(objMunicipality.IdMunicipality) 
                    && Name.Equals(objMunicipality.Name);
            }
            return false;
        }
    }
}
