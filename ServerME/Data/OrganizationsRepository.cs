using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ServerME.Models;
using ServerME.Enums;
using ServerME.Utils;

namespace ServerME.Data
{
    public class OrganizationsRepository
    {
        private Utils.Logger<Organization> logger;
        public OrganizationsRepository()
        {
            logger = new Utils.Logger<Organization>();
        }

        public List<Organization> GetOrganizations(string filter, string sorting,
    Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var organizations = GetOrganizationsList(filter, sorting, privilege, currentPage, pageSize);

            return organizations;
        }

        private List<Organization> GetOrganizationsList(string filter, string sorting,
            Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var filterValues = filter.Split(';');
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);

            IQueryable<Organization> organizationsQuery;

            using (var dbContext = new Context())
            {
                var priv = privilege.GetValueOrDefault("Organization", "All").Split(';');

                if (priv[0] == "All")
                {
                    organizationsQuery = dbContext.Organizations
                        .Include(org => org.Locality)
                        .Include(org => org.TypeOrganization);
                }
                else
                {
                    var mun = priv[0].Split('=');
                    organizationsQuery = dbContext.Organizations
                        .Include(org => org.Locality)
                        .Include(org => org.TypeOrganization)
                        .Where(org => org.Locality.Municipality.IdMunicipality == int.Parse(mun[1]));
                }

                foreach (var fil in filterValues)
                {
                    var filArray = fil.Split('=');
                    organizationsQuery = ApplyFilter(organizationsQuery, filArray);
                }

                foreach (var sort in sortValues)
                {
                    var sortArray = sort.Split('=');
                    organizationsQuery = ApplySorting(organizationsQuery, sortArray);
                }

                return organizationsQuery
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        private IQueryable<Organization> ApplyFilter(IQueryable<Organization> organizationsQuery, string[] filArray)
        {
            return filArray[0] switch
            {
                "NameOrg" => filArray[1] != " " ? organizationsQuery.Where(org => org.Name.Contains(filArray[1])) : organizationsQuery,
                "TaxIdNumber" => filArray[1] != " " ? organizationsQuery.Where(org => org.TaxIdNumber.Contains(filArray[1])) : organizationsQuery,
                "CodeReason" => filArray[1] != " " ? organizationsQuery.Where(org => org.CodeReason.Contains(filArray[1])) : organizationsQuery,
                "Address" => filArray[1] != " " ? organizationsQuery.Where(org => org.Address.Contains(filArray[1])) : organizationsQuery,
                "TypeOrganization" => filArray[1] != " " ? organizationsQuery.Where(org => org.TypeOrganization.Name.Contains(filArray[1])) : organizationsQuery,
                "IsJuridicalPerson" => filArray[1] != " " ? organizationsQuery.Where(org => org.IsJuridicalPerson.ToString().Contains(filArray[1])) : organizationsQuery,
                "Locality" => filArray[1] != " " ? organizationsQuery.Where(org => org.Locality.Name.Contains(filArray[1])) : organizationsQuery,
                _ => organizationsQuery,
            };
        }

        private IQueryable<Organization> ApplySorting(IQueryable<Organization> organizationsQuery, string[] sortArray)
        {

            var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
            return sortArray[0] switch
            {
                "NameOrg" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.Name) : organizationsQuery.OrderByDescending(org => org.Name),
                "TaxIdNumber" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.TaxIdNumber) : organizationsQuery.OrderByDescending(org => org.TaxIdNumber),
                "CodeReason" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.CodeReason) : organizationsQuery.OrderByDescending(org => org.CodeReason),
                "Address" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.Address) : organizationsQuery.OrderByDescending(org => org.Address),
                "TypeOrganization" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.TypeOrganization.Name) : organizationsQuery.OrderByDescending(org => org.TypeOrganization.Name),
                "IsJuridicalPerson" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.IsJuridicalPerson) : organizationsQuery.OrderByDescending(org => org.IsJuridicalPerson),
                "Locality" => sortDirection == SortDirection.Ascending ? organizationsQuery.OrderBy(org => org.Locality.Name) : organizationsQuery.OrderByDescending(org => org.Locality.Name),
                _ => organizationsQuery,
            };
        }

        public List<Organization> GetOrganizationsForContract(Dictionary<string, string> privilege)
        {
            var mun = privilege["Organization"].Split(';')[0].Split('=');
            using (var dbContext = new Context())
            {
                return dbContext.Organizations
                    .Include(p => p.Locality.Municipality)
                    .Include(p => p.TypeOrganization)
                    .Where(org => org.Locality.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
            }
        }
        public List<Organization> GetOrganizationsForReport(User user)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Organizations
                    .Include(p => p.Locality.Municipality)
                    .Include(p => p.TypeOrganization)
                    .Where(org => org.Locality.Municipality.IdMunicipality == user.Organization.Locality.Municipality.IdMunicipality).ToList();
            }
        }

        public Organization GetOrganization(int organizationId)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Organizations.Include(p => p.Locality).Include(p => p.TypeOrganization).First(org => org.IdOrganization == organizationId);
            }
        }

        public void AddOrganization(User user, Organization organization)
        {
            using (var dbContext = new Context())
            {
                try 
                { 
                    organization.Locality = dbContext.Localities.Include(p => p.Municipality).First(x => x.IdLocality == organization.Locality.IdLocality);
                    organization.TypeOrganization = dbContext.TypeOrganizations.First(x => x.IdTypeOrganization == organization.TypeOrganization.IdTypeOrganization);
                    dbContext.Organizations.Add(organization);
                    dbContext.SaveChanges();
                    logger.LogAdding(user, organization);
                }
                catch (DbUpdateException e)
                {
                    var postEx = e.InnerException as PostgresException;
                    var errorColumn = postEx.ConstraintName.Split('_').Last();
                    errorColumn = ErrorMessage(errorColumn);
                    throw new ArgumentException(errorColumn);
                }
            }
        }

        public void UpdateOrganization(User user, Organization organization)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    var oldValue = dbContext.Organizations
                        .AsNoTracking()
                        .Include(p => p.Locality.Municipality)
                        .Include(p => p.TypeOrganization)
                        .First(p => p.IdOrganization ==  organization.IdOrganization);

                    dbContext.Organizations.Update(organization);
                    dbContext.SaveChanges();
                    logger.LogUpdating(user, oldValue, organization);

                }
                catch (DbUpdateException e)
                {
                    var postEx = e.InnerException as PostgresException;
                    var errorColumn = postEx.ConstraintName.Split('_').Last();
                    errorColumn = ErrorMessage(errorColumn);
                    throw new ArgumentException(errorColumn);
                }
            }
        }

        public void DeleteOrganization(User user, int organizationId)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    dbContext.Organizations.Where(p => p.IdOrganization == organizationId).ExecuteDelete();
                    logger.LogRemoving(user, organizationId);
                }
                catch (Exception)
                {
                    Console.WriteLine("Удаление карточки");
                    throw new InvalidOperationException("Удаление организации невозможно, " +
                        "так как используется для осмотров, либо контрактов");
                }
            }
        }

        private IEnumerable<Organization> ApplySorting(IEnumerable<Organization> filteredOrganizations, string[] sortValues)
        {
            List<Organization> sortedOrganizations = new List<Organization>();
            foreach (var sort in sortValues)
            {
                var sortArray = sort.Split('=');
                var sortColumn = sortArray[0];
                var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
                switch (sortColumn)
                {
                    case "NameOrg":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.Name).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.Name).ToList();
                        break;
                    case "TaxIdNumber":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.TaxIdNumber).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.TaxIdNumber).ToList();
                        break;
                    case "CodeReason":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.CodeReason).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.CodeReason).ToList();
                        break;
                    case "Address":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.Address).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.Address).ToList();
                        break;
                    case "TypeOrganization":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.TypeOrganization.Name).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.TypeOrganization.Name).ToList();
                        break;
                    case "IsJuridicalPerson":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.IsJuridicalPerson).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.IsJuridicalPerson).ToList();
                        break;
                    case "Locality":
                        sortedOrganizations = (sortDirection == SortDirection.Ascending)
                            ? filteredOrganizations.OrderBy(org => org.Locality.Name).ToList()
                            : filteredOrganizations.OrderByDescending(org => org.Locality.Name).ToList();
                        break;
                    default:
                        sortedOrganizations = filteredOrganizations.ToList();
                        break;
                }
            }
            return sortedOrganizations;
        }

        private string ErrorMessage(string errorColumn)
        {
            switch (errorColumn)
            {
                case "Name":
                    errorColumn = "Организация с таким названием существует!";
                    break;
                case "CodeReason":
                    errorColumn = "Организация с таким КПП существует!";
                    break;
                case "TaxIdNumber":
                    errorColumn = "Организация с таким ИНН существует!";
                    break;
                default:
                    break;
            }
            return errorColumn;
        }
    }
}
