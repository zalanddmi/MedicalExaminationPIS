using Newtonsoft.Json;

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
        
        [JsonIgnore] 
        public List<Examination> Examinations { get; set; } = new();
        public MunicipalContract()
        {

        }
        public MunicipalContract(string number, DateTime dateConclusion, DateTime dateAction, 
            List<string> scan, Organization executor, Organization customer)
        {
            Number = number;
            DateConclusion = dateConclusion;
            DateAction = dateAction;
            Scan = scan;
            Executor = executor;
            Customer = customer;
        }

        public MunicipalContract(int idMunicipalContract, string number, DateTime dateConclusion, DateTime dateAction,
            List<string> scan, Organization executor, Organization customer)
        {
            IdMunicipalContract = idMunicipalContract;
            Number = number;
            DateConclusion = dateConclusion;
            DateAction = dateAction;
            Scan = scan;
            Executor = executor;
            Customer = customer;
        }

        public override string ToString()
        {
            var result = $"Number - {Number}\nDateConclusion - {DateConclusion}\nDateAction - {DateAction}" +
                $"\nExecutorIdOrganization - {Executor.IdOrganization}\nCustomerIdOrganization - {Customer.IdOrganization}";
            return result;
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj is MunicipalContract objContract)
            {
                return IdMunicipalContract.Equals(objContract.IdMunicipalContract) && Number.Equals(objContract.Number)
                    && DateAction.Equals(objContract.DateAction) && DateConclusion.Equals(objContract.DateConclusion)
                    && Executor.IdOrganization.Equals(objContract.Executor.IdOrganization)
                    && Customer.IdOrganization.Equals(objContract.Customer.IdOrganization);
            }
            return false;
        }
    }
}
