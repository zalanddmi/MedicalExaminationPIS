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

        public override string ToString()
        {
            var result = $"Value - {Value}\nIdLocality - {Locality.IdLocality}" +
                $"\nIdMunicipalContract - {MunicipalContract.IdMunicipalContract}";
            return result;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj is Cost objCost)
            {
                return IdCost.Equals(objCost.IdCost) && Value.Equals(objCost.Value)
                    && Locality.IdLocality.Equals(objCost.Locality.IdLocality)
                    && MunicipalContract.IdMunicipalContract.Equals(objCost.MunicipalContract.IdMunicipalContract);
            }
            return false;
        }
    }
}
