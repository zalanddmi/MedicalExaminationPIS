namespace ServerME.Models
{
    public class MunicipalContract
    {
        public int IdMunicipalContract { get; set; }
        public string Number { get; set; }
        public DateTime DateConclusion { get; set; }
        public DateTime DateAction { get; set; }
        public List<string> Scan { get; set; }
        public Organization Executor { get; set; }
        public Organization Customer { get; set; }

        public MunicipalContract()
        {

        }
        public MunicipalContract (string number, DateTime dateConclusion, DateTime dateAction, 
            List<string> scan, Organization executor, Organization customer)
        {
            Number = number;
            DateConclusion = dateConclusion;
            DateAction = dateAction;
            Scan = scan;
            Executor = executor;
            Customer = customer;
        }
    }
}
