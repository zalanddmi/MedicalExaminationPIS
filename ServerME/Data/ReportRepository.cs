using ServerME.Models;
using ServerME.Enums;
using Microsoft.EntityFrameworkCore;

namespace ServerME.Data
{
    public class ReportRepository
    {
        public List<Report> GetReports(string filter, string sorting, Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var reports = GetReportsList(filter, sorting, privilege, currentPage, pageSize);

            return reports;
        }

        private List<Report> GetReportsList(string filter, string sorting, Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var filterValues = filter.Split(';');
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);

            IQueryable<Report> query;

            using (var dbContext = new Context())
            {

                var priv = privilege["Reports"].Split(';');

                if (priv[0].Split('=')[0] == "Mun")
                {
                    var mun = priv[0].Split('=');
                    query = dbContext.Reports
                        .Include(p => p.Organization)
                        .Include(p => p.Creator)
                        .Where(p => p.Organization.Locality.Municipality.IdMunicipality == int.Parse(mun[1]));
                }
                else if (priv[0].Split('=')[0] == "Org")
                {
                    var org = priv[0].Split('=');
                    query = dbContext.Reports
                        .Include(p => p.Organization)
                        .Include(p => p.Creator)
                        .Where(p => p.Organization.IdOrganization == int.Parse(org[1]));
                }
                else
                {
                    query = dbContext.Reports
                        .Include(p => p.Organization)
                        .Include(p => p.Creator);
                }

                foreach (var fil in filterValues)
                {
                    var filArray = fil.Split('=');
                    query = ApplyFilter(query, filArray);
                }

                foreach (var sort in sortValues)
                {
                    var sortArray = sort.Split('=');
                    query = ApplySorting(query, sortArray);
                }

                return query
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        private IQueryable<Report> ApplyFilter(IQueryable<Report> query, string[] filArray)
        {
            return filArray[0] switch
            {
                "StartDate" => filArray[1] != " " ? query.Where(ani => ani.StartDate.ToString().Contains(filArray[1])) : query,
                "EndDate" => filArray[1] != " " ? query.Where(ani => ani.EndDate.ToString().Contains(filArray[1])) : query,
                "Organization" => filArray[1] != " " ? query.Where(ani => ani.Organization.Name.Contains(filArray[1])) : query,
                "Creator" => filArray[1] != " " ? query.Where(ani => ani.Creator.Name.Contains(filArray[1])) : query,
                "Status" => filArray[1] != " " ? query.Where(ani => ani.Status.Contains(filArray[1])) : query,
                "StatusDate" => filArray[1] != " " ? query.Where(ani => ani.StatusDate.ToString().Contains(filArray[1])) : query,
                _ => query,
            };
        }

        private IQueryable<Report> ApplySorting(IQueryable<Report> query, string[] sortArray)
        {
            var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
            return sortArray[0] switch
            {
                "StartDate" => sortDirection == SortDirection.Ascending ? query.OrderBy(ani => ani.StartDate) : query.OrderByDescending(ani => ani.StartDate),
                "EndDate" => sortDirection == SortDirection.Ascending ? query.OrderBy(ani => ani.EndDate) : query.OrderByDescending(ani => ani.EndDate),
                "Organization" => sortDirection == SortDirection.Ascending ? query.OrderBy(ani => ani.Organization) : query.OrderByDescending(ani => ani.Organization),
                "Creator" => sortDirection == SortDirection.Ascending ? query.OrderBy(ani => ani.Creator.Name) : query.OrderByDescending(ani => ani.Creator.Name),
                "Status" => sortDirection == SortDirection.Ascending ? query.OrderBy(ani => ani.Status) : query.OrderByDescending(ani => ani.Status),
                "StatusDate" => sortDirection == SortDirection.Ascending ? query.OrderBy(ani => ani.StatusDate) : query.OrderByDescending(ani => ani.StatusDate),
                _ => query,
            };
        }

        public Report Get(int id)
        {
            using (var dbContext = new Context())
            {
                return dbContext.Reports
                    .Include(p => p.Organization)
                    .Include(p => p.Creator)
                    .First(p => p.Id == id);
            }
        }

        public void Add(Report report)
        {
            using (var dbContext = new Context())
            {
                report.Organization = dbContext.Organizations.First(p => p.IdOrganization == report.Organization.IdOrganization);
                report.Creator = dbContext.Users.First(p => p.IdUser == report.Creator.IdUser);
                dbContext.Reports.Add(report);
                dbContext.SaveChanges();
            }
        }

        public void Update(Report report)
        {
            using (var dbContext = new Context())
            {
                var oldValue = dbContext.Reports
                    .AsNoTracking()
                    .Include(p => p.Creator)
                    .Include(p => p.Organization)
                    .First(p => p.Id == report.Id);
                report.Creator = oldValue.Creator;
                report.Organization = oldValue.Organization;
                report.FilePath = oldValue.FilePath;

                dbContext.Reports.Update(report);
                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var dbContext = new Context())
            {
                dbContext.Reports.Where(p => p.Id == id).ExecuteDelete();
            }
        }

        public List<string> GetStatusReport(User user)
        {
            var role = user.Role;

            switch (role.Name)
            {
                case "Оператор ОМСУ":
                    return new List<string>() { "Черновик", "Согласование у исполнителя" };
                case "Куратор приюта":
                    return new List<string>() { "Доработка", "Согласован у исполнителя" };
                case "Подписант приюта":
                    return new List<string>() { "Доработка", "Утвержден у исполнителя" };
                case "Куратор ОМСУ":
                    return new List<string>() { "Доработка", "Согласован ОМСУ" };
                default:
                    return new List<string>() { "Нет статуса" };
            }
        }
    }
}
