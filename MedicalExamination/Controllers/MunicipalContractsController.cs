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

        public string[] ShowMunicipalContractsToView(string choosedMunicipalContract)
        {
            return new MunicipalContractsService().GetMunicipalContractCardToView(choosedMunicipalContract);
        }

        public string[] ShowOrganizationCardToEdit(string choosedMunicipalContract)
        {
            return new MunicipalContractsService().GetMunicipalContractCardToEdit(choosedMunicipalContract);
        }

      //  public void AddOrganization(string[] )
      //  {
        //    
        //}

        public void EditMunicipalContract(string choosedMunicipalContract, string[] Data)
        {
            // все также упирается в привелегии 
        }

        public void DeleteMunicipalContract(string choosedOrganization)
        {
            // все также упирается в привелегии
        }

        public void ExportMunicipalContractsToExcel(string filter, string sorting, string[] columnNames)
        {
            new MunicipalContractsService().ExportMunicipalContractsToExcel(filter, sorting, columnNames);
        }
    }
}
