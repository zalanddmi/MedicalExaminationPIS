namespace ServerME.Models
{
    public class Cost
    {
        public int IdCost { get; set; }
        public double Value { get; set; }
        public Locality Locality { get; set; }
        public MunicipalContract MunicipalContract { get; set; }


        public Cost()
        {

        }

        public Cost(double value, Locality locality, MunicipalContract municipalContract)
        {
            Value = value;
            Locality = locality;
            MunicipalContract = municipalContract;
        }

        public Cost (int idCost, double value, Locality locality, MunicipalContract municipalContract)
        {
            IdCost = idCost;
            Value = value;
            Locality = locality;
            MunicipalContract = municipalContract;
        }
    }
}
