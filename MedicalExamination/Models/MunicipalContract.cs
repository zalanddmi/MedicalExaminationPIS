using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedicalExamination.Models
{
    public class MunicipalContract
    {
        public string Number;
        public DateTime DateConclusion;
        public DateTime DateAction;
        public List<Image> Scan;
        public Organization Executor;
        public Organization Customer;

        public MunicipalContract (string number, DateTime dateConclusion, DateTime dateAction, 
            List<Image> scan, Organization customer, Organization executor)
        {
            Number = number;
            DateConclusion = dateConclusion;
            DateAction = dateAction;
            Scan = scan;
            Executor = executor;
            Customer = customer;
        }
    }
    public class Cost
    {
        public double Value;
        public Locality Locality;
        public MunicipalContract MunicipalContract;

        public Cost (double value, Locality locality, MunicipalContract municipalContract)
        {
            Value = value;
            Locality = locality;
            MunicipalContract = municipalContract;
        }
    }
}
