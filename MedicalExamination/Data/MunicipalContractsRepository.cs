using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public class MunicipalContractsRepository
    {
        public MunicipalContractsRepository()
        {

        }

        public MunicipalContract GetMunicipalContract (string choosedMunicipalConatract)
        {
            var idMunicipalContract = Convert.ToUInt32(choosedMunicipalConatract);
            var municipalcontract = TestData.MunicipalContracts.First(mun => mun.IdMunicipalContract == idMunicipalContract);
            return municipalcontract;       
        }
        public void AddMunicipalContract (MunicipalContract municipalcontract)
        {
            var maxId = TestData.MunicipalContracts.Max(mun => mun.IdMunicipalContract);
            municipalcontract.IdMunicipalContract = maxId + 1;
            TestData.MunicipalContracts.Add(municipalcontract);
        }
        public void DeleteMunicipalContract(string choosedMunicipalConatract)
        {
            var idMunicipalContract = Convert.ToUInt32(choosedMunicipalConatract);
            TestData.MunicipalContracts.RemoveAll(mun => mun.IdMunicipalContract == idMunicipalContract);
        }
        public void UpdateMunicipalContract(string choosedMunicipalConatract, MunicipalContract municipalcontract)
        {
            var idMunicipalContract = Convert.ToUInt32(choosedMunicipalConatract);
            municipalcontract.IdMunicipalContract = Convert.ToInt32(idMunicipalContract);
            TestData.MunicipalContracts[Convert.ToInt32(idMunicipalContract) - 1] = municipalcontract;
        }

        public List<MunicipalContract> GetMunicipalContracts(string filter, string sorting, Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);
            var filterValues = filter.Split(';');
            var municipalcontracts = new List<MunicipalContract>();
            var priv = privilege["MunicipalContract"].Split(';');
            if (priv[0] == "All")
            {
                municipalcontracts = TestData.MunicipalContracts;
            }
            else if (priv[0].StartsWith("Org"))
            {
                var org = priv[0].Split('=');
                municipalcontracts = TestData.MunicipalContracts.Where(munC => munC.Executor.IdOrganization == int.Parse(org[1])).ToList();
            }
            else if (priv[0].StartsWith("Mun"))
            {
                var mun = priv[0].Split('=');
                var costs = TestData.Costs.Where(c => c.Locality.Municipality.IdMunicipality == int.Parse(mun[1]));
                var idMunCon = costs.Select(c => c.IdCost).ToList();
                idMunCon.Sort();
                for (int i = 0; i < idMunCon.Count; i++)
                {
                    municipalcontracts.Add(TestData.MunicipalContracts.First(munC => munC.IdMunicipalContract == idMunCon[i]));
                }
            }

            IEnumerable<MunicipalContract> filteredMunicipalContracts = municipalcontracts;
            foreach (var fil in filterValues)
            {
                var filArray = fil.Split('=');
                filteredMunicipalContracts = filArray[0] == "Number" && filArray[1] != " "
                    ? filteredMunicipalContracts.Where(org => org.Number.Contains(filArray[1]))
                    : filteredMunicipalContracts;
                filteredMunicipalContracts = filArray[0] == "DateConclusion" && filArray[1] != " "
                    ? filteredMunicipalContracts.Where(org => org.DateConclusion.ToString().Contains(filArray[1]))
                    : filteredMunicipalContracts;
                filteredMunicipalContracts = filArray[0] == "DateAction" && filArray[1] != " "
                    ? filteredMunicipalContracts.Where(org => org.DateAction.ToString().Contains(filArray[1]))
                    : filteredMunicipalContracts;
                filteredMunicipalContracts = filArray[0] == "Executor" && filArray[1] != " "
                    ? filteredMunicipalContracts.Where(org => org.Executor.Name.Contains(filArray[1]))
                    : filteredMunicipalContracts;
                filteredMunicipalContracts = filArray[0] == "Customer" && filArray[1] != " "
                    ? filteredMunicipalContracts.Where(org => org.Customer.Name.Contains(filArray[1]))
                    : filteredMunicipalContracts;                
            }
            var sortedMunicipalContracts = ApplySorting(filteredMunicipalContracts, sortValues);
            return sortedMunicipalContracts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        private IEnumerable<MunicipalContract> ApplySorting(IEnumerable<MunicipalContract> filteredMunicipalContracts, string[] sortValues)
        {
            List<MunicipalContract> sortedMunicipalContracts = new List<MunicipalContract>();
            foreach (var sort in sortValues)
            {
                var sortArray = sort.Split('=');
                var sortColumn = sortArray[0];
                var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
                switch (sortColumn)
                {
                    case "Number":
                        sortedMunicipalContracts = (sortDirection == SortDirection.Ascending)
                            ? filteredMunicipalContracts.OrderBy(mun => mun.Number).ToList()
                            : filteredMunicipalContracts.OrderByDescending(mun => mun.Number).ToList();
                        break;
                    case "DateConclusion":
                        sortedMunicipalContracts = (sortDirection == SortDirection.Ascending)
                            ? filteredMunicipalContracts.OrderBy(mun => mun.DateConclusion).ToList()
                            : filteredMunicipalContracts.OrderByDescending(mun => mun.DateConclusion).ToList();
                        break;
                    case "DateAction":
                        sortedMunicipalContracts = (sortDirection == SortDirection.Ascending)
                            ? filteredMunicipalContracts.OrderBy(mun => mun.DateAction).ToList()
                            : filteredMunicipalContracts.OrderByDescending(mun => mun.DateAction).ToList();
                        break;
                    case "Executor":
                        sortedMunicipalContracts = (sortDirection == SortDirection.Ascending)
                            ? filteredMunicipalContracts.OrderBy(mun => mun.Executor).ToList()
                            : filteredMunicipalContracts.OrderByDescending(mun => mun.Executor).ToList();
                        break;
                    case "Customer":
                        sortedMunicipalContracts = (sortDirection == SortDirection.Ascending)
                            ? filteredMunicipalContracts.OrderBy(mun => mun.Customer).ToList()
                            : filteredMunicipalContracts.OrderByDescending(mun => mun.Customer).ToList();
                        break;
                        
                    default:
                        sortedMunicipalContracts = filteredMunicipalContracts.ToList();
                        break;
                }
            }
            return sortedMunicipalContracts;
        }

        private enum SortDirection
        {
            Ascending,
            Descending
        }

    }
}
