using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.EntityFrameworkCore;
using ServerME.Models;

namespace ServerME.Data
{
    public class MunicipalContractsRepository
    {
        public MunicipalContractsRepository()
        {

        }
        private List<MunicipalContract> GetAllContracts()
        {
            using (var dbContext = new Context())
            {
                return dbContext.MunicipalContracts
                    .Include(p => p.Executor.TypeOrganization)
                    .Include(p => p.Executor.Locality.Municipality)
                    .Include(p => p.Customer.TypeOrganization)
                    .Include(p => p.Customer.Locality.Municipality).ToList();
            }
        }
        private List<Cost> GetAllCosts()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Costs
                    .Include(p => p.MunicipalContract.Executor.TypeOrganization)
                    .Include(p => p.MunicipalContract.Executor.Locality.Municipality)
                    .Include(p => p.MunicipalContract.Customer.TypeOrganization)
                    .Include(p => p.MunicipalContract.Customer.Locality.Municipality)
                    .Include(p => p.Locality.Municipality).ToList();
            }
        }
        public List<MunicipalContract> GetContractsForOrganization(Organization organization)
        {
            var result = GetAllContracts();
            return result
                .Where(con => con.Executor.IdOrganization == organization.IdOrganization 
                    && con.DateConclusion < DateTime.Now && con.DateAction > DateTime.Now).ToList();
        }
        public MunicipalContract GetMunicipalContract(int municipalContractId)
        {
            return GetAllContracts()
                .First(mun => mun.IdMunicipalContract == municipalContractId);
        }

        public List<Cost> GetCosts(int municipalContractId)
        {
            var costs = GetAllCosts().Where(cost => cost.MunicipalContract.IdMunicipalContract == municipalContractId).ToList();
            return costs;
        }

        private void SaveContract(MunicipalContract municipalContract)
        {
            using (var dbContext = new Context())
            {
                municipalContract.Executor = dbContext.Organizations.First(p => p.IdOrganization == municipalContract.Executor.IdOrganization);
                municipalContract.Customer = dbContext.Organizations.First(p => p.IdOrganization == municipalContract.Customer.IdOrganization);
                dbContext.MunicipalContracts.Add(municipalContract);
                dbContext.SaveChanges();
            }
        }
        private void UpdateContract(MunicipalContract municipalContract)
        {
            using (var dbContext = new Context())
            {
                municipalContract.Executor = dbContext.Organizations.First(p => p.IdOrganization == municipalContract.Executor.IdOrganization);
                municipalContract.Customer = dbContext.Organizations.First(p => p.IdOrganization == municipalContract.Customer.IdOrganization);
                dbContext.MunicipalContracts.Update(municipalContract);
                dbContext.SaveChanges();
            }
        }
        private void RemoveContract(int contractId)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    dbContext.MunicipalContracts.Where(p => p.IdMunicipalContract == contractId).ExecuteDelete();
                }
                catch (Exception)
                {
                    Console.WriteLine("Удаление карточки");
                    throw new InvalidOperationException("Удаление контракта невозможно, " +
                        "так как контракт используется для осмотров");
                }
            }
        }
        private void SaveCost(Cost cost)
        {
            using (var dbContext = new Context())
            {
                cost.Locality = dbContext.Localities.First(p => p.IdLocality == cost.Locality.IdLocality);
                cost.MunicipalContract = dbContext.MunicipalContracts.First(p => p.IdMunicipalContract == cost.MunicipalContract.IdMunicipalContract);
                dbContext.Costs.Add(cost);
                dbContext.SaveChanges();
            }
        }
        private void UpdateCost(Cost cost)
        {
            using (var dbContext = new Context())
            {
                cost.Locality = dbContext.Localities.First(p => p.IdLocality == cost.Locality.IdLocality);
                cost.MunicipalContract = dbContext.MunicipalContracts.First(p => p.IdMunicipalContract == cost.MunicipalContract.IdMunicipalContract);
                dbContext.Costs.Update(cost);
                dbContext.SaveChanges();
            }
        }
        private void RemoveCost(int costId)
        {
            using (var dbContext = new Context())
            {
                var cost = dbContext.Costs.FirstOrDefault(p => p.IdCost == costId);
                if (cost is null)
                {
                    return;
                }
                dbContext.Costs.Remove(cost);
                dbContext.SaveChanges();
            }
        }
        public void AddMunicipalContract(MunicipalContract municipalContract, List<Cost> costs)
        {
            SaveContract(municipalContract);
            foreach (var cost in costs)
            {
                cost.MunicipalContract.IdMunicipalContract = municipalContract.IdMunicipalContract;
                SaveCost(cost);
            }
        }

        public void UpdateMunicipalContract(MunicipalContract municipalContract, List<Cost> costs)
        {
            UpdateContract(municipalContract);

            var costsWithContract = GetAllCosts().Where(c => c.MunicipalContract.IdMunicipalContract == municipalContract.IdMunicipalContract);

            var costsNeededDelete = costsWithContract.Where(c => costs.FirstOrDefault(p => p.IdCost == c.IdCost) is null);


            foreach (var cost in costsNeededDelete)
            {
                RemoveCost(cost.IdCost);
            }
            foreach (var cost in costs)
            {
                var currentCost = costsWithContract.FirstOrDefault(p => p.IdCost == cost.IdCost);
                cost.MunicipalContract.IdMunicipalContract = municipalContract.IdMunicipalContract;
                if (currentCost is null)
                {
                    SaveCost(cost);
                }
                else
                {
                    UpdateCost(cost);
                }
            }
        }

        public void DeleteMunicipalContract(int municipalContractId)
        {
            RemoveContract(municipalContractId);
        }

        public List<MunicipalContract> GetMunicipalContracts(string filter, string sorting, Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);
            var filterValues = filter.Split(';');
            var municipalcontracts = new List<MunicipalContract>();
            var priv = new List<string>();
            Console.WriteLine(String.Join("|", GetAllContracts().Select(p => p.Number).ToArray()));
            if (privilege.ContainsKey("MunicipalContract"))
            {
                priv = privilege["MunicipalContract"].Split(';').ToList();
                if (priv[0] == "All")
                {
                    municipalcontracts = GetAllContracts();
                }
                else if (priv[0].StartsWith("Org"))
                {
                    var org = priv[0].Split('=');
                    municipalcontracts = GetAllContracts().Where(munC => munC.Executor.IdOrganization == int.Parse(org[1])).ToList();
                }
                else if (priv[0].StartsWith("Mun"))
                {
                    var mun = priv[0].Split('=');
                    var costs = GetAllCosts().Where(c => c.Locality.Municipality.IdMunicipality == int.Parse(mun[1]));
                    var idMunCon = costs.Select(c => c.MunicipalContract.IdMunicipalContract).Distinct().ToList();
                    idMunCon.Sort();
                    for (int i = 0; i < idMunCon.Count; i++)
                    {
                        municipalcontracts.Add(GetAllContracts().First(munC => munC.IdMunicipalContract == idMunCon[i]));
                    }
                }
            }
            else if (privilege.ContainsKey("Examination"))
            {
                priv = privilege["Examination"].Split(';').ToList();
                var org = priv[1].Split('=');
                municipalcontracts = GetAllContracts().Where(munC => munC.Executor.IdOrganization == int.Parse(org[1])).ToList();
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
            List<MunicipalContract> sortedMunicipalContracts = filteredMunicipalContracts.ToList();
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
