using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.ViewModels
{
    public class MunicipalContractView
    {
        public int IdMunicipalContract { get; set; }
        public string Number { get; set; }
        public DateTime DateConclusion { get; set; }
        public DateTime DateAction { get; set; }
        public List<Image> Scan { get; set; }
        public Organization Executor { get; set; }
        public Organization Customer { get; set; }

        public MunicipalContractView()
        {

        }

        public MunicipalContractView(int idMunicipalContract, string number, DateTime dateConclusion, DateTime dateAction, List<Image> scan, Organization executor, Organization customer)
        {
            IdMunicipalContract = idMunicipalContract;
            Number = number;
            DateConclusion = dateConclusion;
            DateAction = dateAction;
            Scan = scan;
            Executor = executor;
            Customer = customer;
        }

        public MunicipalContractView(string number, DateTime dateConclusion, DateTime dateAction, List<Image> scan, Organization executor, Organization customer)
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
