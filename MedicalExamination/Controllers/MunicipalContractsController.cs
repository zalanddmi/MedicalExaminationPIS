using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;

namespace MedicalExamination.Controllers
{
    class MunicipalContractsController
    {
        public List<string[]> ShowMunicipalContracts(string filter, string sorting, int currentPage, int pageSize)
        {
            return new MunicipalContractsService().GetMunicipalContracts(filter, sorting, currentPage, pageSize);
        }

        public string[] ShowMunicipalContractCardToView(string choosedMunicipalContract)
        {
            return new MunicipalContractsService().GetMunicipalContractCardToView(choosedMunicipalContract);
        }

        public string[] ShowMunicipalContractCardToEdit(string choosedMunicipalContract)
        {
            return new MunicipalContractsService().GetMunicipalContractCardToEdit(choosedMunicipalContract);
        }

        public void AddMunicipalContract(string[] municipalcontractData, List<string> Photos)
        {
            new MunicipalContractsService().MakeMunicipalContract(municipalcontractData, Photos);
        }

        public void EditMunicipalContract(string choosedMunicipalContract, string[] municipalcontractData, List<string> Photos)
        {
            new MunicipalContractsService().EditMunicipalContract(choosedMunicipalContract, municipalcontractData, Photos);
        }

        public void DeleteMunicipalContract(string choosedMunicipalContract)
        {
            new MunicipalContractsService().DeleteMunicipalContract(choosedMunicipalContract);
        }

        public void ExportMunicipalContractsToExcel(string filter, string sorting, string[] columnNames)
        {
            new MunicipalContractsService().ExportMunicipalContractsToExcel(filter, sorting, columnNames);
        }
    }
}
