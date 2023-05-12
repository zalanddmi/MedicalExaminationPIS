using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedicalExamination.Models
{
    public class Municipal_contract
    {
        public string Number;
        public DateTime DateConclusion;
        public DateTime DateAction;
        public List<Image> Scan;
        public Organization Organization;
        public Cost Cost;
        public Municipal_contract ( string number, DateTime dateConclusion, DateTime dateAction, 
            List<Image> scan, Organization organization, Cost cost)
        {
            Number = number;
            DateConclusion = dateConclusion;
            DateAction = dateAction;
            Scan = scan;
            Organization = organization;
            Cost = cost;
        }
    }
    public class Cost
    {
        public string Value;
        public Locality Locality;
        public Cost (string value, Locality locality)
        {
            Value = value;
            Locality = locality;
        }
    }
}
