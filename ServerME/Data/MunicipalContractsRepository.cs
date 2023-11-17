using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.EntityFrameworkCore;
using ServerME.Models;
using ServerME.Enums;

namespace ServerME.Data
{
    public class MunicipalContractsRepository
    {
        public MunicipalContractsRepository()
        {

        }

        public List<MunicipalContract> GetMunicipalContracts(string filter, string sorting,
    Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var municipalContracts = GetMunicipalContractsList(filter, sorting, privilege, currentPage, pageSize);

            return municipalContracts;
        }

        private List<MunicipalContract> GetMunicipalContractsList(string filter, string sorting,
            Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var filterValues = filter.Split(';');
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);

            IQueryable<MunicipalContract> municipalContractsQuery;

            using (var dbContext = new Context())
            {
                var priv = privilege.GetValueOrDefault("MunicipalContract", "All").Split(';').ToList();

                if (priv[0] == "All")
                {
                    municipalContractsQuery = dbContext.MunicipalContracts
                        .Include(munC => munC.Executor)
                        .Include(munC => munC.Customer);
                }
                else if (priv[0].StartsWith("Org"))
                {
                    var org = priv[0].Split('=');
                    municipalContractsQuery = dbContext.MunicipalContracts
                        .Include(munC => munC.Executor)
                        .Include(munC => munC.Customer)
                        .Where(munC => munC.Executor.IdOrganization == int.Parse(org[1]));
                }
                else if (priv[0].StartsWith("Mun"))
                {
                    var mun = priv[0].Split('=');
                    var contractIds = dbContext.Costs
                        .Where(c => c.Locality.Municipality.IdMunicipality == int.Parse(mun[1]))
                        .Select(c => c.MunicipalContract.IdMunicipalContract)
                        .Distinct()
                        .OrderBy(id => id)
                        .ToList();

                    municipalContractsQuery = dbContext.MunicipalContracts
                        .Include(munC => munC.Executor)
                        .Include(munC => munC.Customer)
                        .Where(munC => contractIds.Contains(munC.IdMunicipalContract));
                }
                else
                {
                    municipalContractsQuery = Enumerable.Empty<MunicipalContract>().AsQueryable();
                }

                foreach (var fil in filterValues)
                {
                    var filArray = fil.Split('=');
                    municipalContractsQuery = ApplyFilter(municipalContractsQuery, filArray);
                }

                foreach (var sort in sortValues)
                {
                    var sortArray = sort.Split('=');
                    municipalContractsQuery = ApplySorting(municipalContractsQuery, sortArray);
                }

                return municipalContractsQuery
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        private IQueryable<MunicipalContract> ApplyFilter(IQueryable<MunicipalContract> municipalContractsQuery, string[] filArray)
        {
            return filArray[0] switch
            {
                "Number" => filArray[1] != " " ? municipalContractsQuery.Where(munC => munC.Number.Contains(filArray[1])) : municipalContractsQuery,
                "DateConclusion" => filArray[1] != " " ? municipalContractsQuery.Where(munC => munC.DateConclusion.ToString().Contains(filArray[1])) : municipalContractsQuery,
                "DateAction" => filArray[1] != " " ? municipalContractsQuery.Where(munC => munC.DateAction.ToString().Contains(filArray[1])) : municipalContractsQuery,
                "Executor" => filArray[1] != " " ? municipalContractsQuery.Where(munC => munC.Executor.Name.Contains(filArray[1])) : municipalContractsQuery,
                "Customer" => filArray[1] != " " ? municipalContractsQuery.Where(munC => munC.Customer.Name.Contains(filArray[1])) : municipalContractsQuery,
                _ => municipalContractsQuery,
            };
        }

        private IQueryable<MunicipalContract> ApplySorting(IQueryable<MunicipalContract> municipalContractsQuery, string[] sortArray)
        {
            var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
            return sortArray[0] switch
            {
                "Number" => sortDirection == SortDirection.Ascending ? municipalContractsQuery.OrderBy(munC => munC.Number) : municipalContractsQuery.OrderByDescending(munC => munC.Number),
                    "DateConclusion" => sortDirection == SortDirection.Ascending ? municipalContractsQuery.OrderBy(munC => munC.DateConclusion) : municipalContractsQuery.OrderByDescending(munC => munC.DateConclusion),
                    "DateAction" => sortDirection == SortDirection.Ascending ? municipalContractsQuery.OrderBy(munC => munC.DateAction) : municipalContractsQuery.OrderByDescending(munC => munC.DateAction),
                    "Executor" => sortDirection == SortDirection.Ascending ? municipalContractsQuery.OrderBy(munC => munC.Executor.Name) : municipalContractsQuery.OrderByDescending(munC => munC.Executor.Name),
                    "Customer" => sortDirection == SortDirection.Ascending ? municipalContractsQuery.OrderBy(munC => munC.Customer.Name) : municipalContractsQuery.OrderByDescending(munC => munC.Customer.Name),
                    _ => municipalContractsQuery,
            };
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
    }
}
