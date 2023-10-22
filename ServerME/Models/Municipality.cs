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
        public Municipality(int idMunicipality, string name)
        {
            IdMunicipality = idMunicipality;
            Name = name;
        }
    }
}
