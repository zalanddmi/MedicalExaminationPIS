using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace ServerME.Models
{
    public class MunicipalContract
    {
        [Key]
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
    public class Cost
    {
        [Key]
        public int IdCost { get; set; }
        public double Value { get; set; }
        public Locality Locality { get; set; }
        public MunicipalContract MunicipalContract { get; set; }


        public Cost()
        {

        }
        public Cost (double value, Locality locality, MunicipalContract municipalContract)
        {
            Value = value;
            Locality = locality;
            MunicipalContract = municipalContract;
        }
    }
}
