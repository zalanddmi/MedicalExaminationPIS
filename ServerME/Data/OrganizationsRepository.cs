using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ServerME.Models;

namespace ServerME.Data
{
    public class OrganizationsRepository
    {
        public OrganizationsRepository()
        {

        }

        public List<Organization> GetOrganizations(string filter, string sorting, 
            Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);
            var filterValues = filter.Split(';');
            var organizations = new List<Organization>();
            var priv = privilege["Organization"].Split(';');
            if (priv[0] == "All")
            {
                using (var dbContext = new Context())
                {
                    organizations = dbContext.Organizations.Include(p => p.Locality).Include(p => p.TypeOrganization).ToList();
                }
            }
            else
            {
                var mun = priv[0].Split('=');
                using (var dbContext = new Context())
                {
                    organizations = dbContext.Organizations.Include(p => p.Locality).Include(p => p.TypeOrganization).Where(org => org.Locality.Municipality.IdMunicipality == int.Parse(mun[1])).ToList();
                }
            }
            IEnumerable<Organization> filteredOrganizations = organizations;
            foreach (var fil in filterValues)
            {
                var filArray = fil.Split('=');
                filteredOrganizations = filArray[0] == "Name" && filArray[1] != " "
                    ? filteredOrganizations.Where(org => org.Name.Contains(filArray[1]))
                    : filteredOrganizations;
                filteredOrganizations = filArray[0] == "TaxIdNumber" && filArray[1] != " "
                    ? filteredOrganizations.Where(org => org.TaxIdNumber.Contains(filArray[1]))
                    : filteredOrganizations;
                filteredOrganizations = filArray[0] == "CodeReason" && filArray[1] != " "
                    ? filteredOrganizations.Where(org => org.CodeReason.Contains(filArray[1]))
                    : filteredOrganizations;
                filteredOrganizations = filArray[0] == "Address" && filArray[1] != " "
                    ? filteredOrganizations.Where(org => org.Address.Contains(filArray[1]))
                    : filteredOrganizations;
                filteredOrganizations = filArray[0] == "TypeOrganization" && filArray[1] != " "
                    ? filteredOrganizations.Where(org => org.TypeOrganization.Name.Contains(filArray[1]))
                    : filteredOrganizations;
                filteredOrganizations = filArray[0] == "Locality" && filArray[1] != " "
                    ? filteredOrganizations.Where(org => org.Locality.Name.Contains(filArray[1]))
                    : filteredOrganizations;
            }
            var sortedOrganizations = ApplySorting(filteredOrganizations, sortValues);
            return sortedOrganizations
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public Organization GetOrganization(int organizationId)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Organizations.Include(p => p.Locality).Include(p => p.TypeOrganization).First(org => org.IdOrganization == organizationId);
            }
        }

        public void AddOrganization(Organization organization)
        {
            using (var dbContext = new Context())
            {
                try 
                { 
                    organization.Locality = dbContext.Localities.Include(p => p.Municipality).First(x => x.IdLocality == organization.Locality.IdLocality);
                    organization.TypeOrganization = dbContext.TypeOrganizations.First(x => x.IdTypeOrganization == organization.TypeOrganization.IdTypeOrganization);
                    dbContext.Organizations.Add(organization);
                    dbContext.SaveChanges();
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

        public void UpdateOrganization(Organization organization)
        {
            using (var dbContext = new Context())
            {
                try
                {
                    dbContext.Organizations.Update(organization);
                    dbContext.SaveChanges();
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

        public void DeleteOrganization(int organizationId)
        {
            using (var dbContext = new Context())
            {
                var organization = dbContext.Organizations.FirstOrDefault(org => org.IdOrganization == organizationId);
                if (organization != null)
                {
                    dbContext.Organizations.Remove(organization);
                    dbContext.SaveChanges();
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

        private enum SortDirection
        {
            Ascending,
            Descending
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
