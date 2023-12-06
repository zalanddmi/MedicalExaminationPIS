using ServerME.Models;
using ServerME.Enums;
using Microsoft.EntityFrameworkCore;

namespace ServerME.Data
{
    public class ReportRepository
    {
        public List<Report> GetReports(string filter, string sorting, int currentPage, int pageSize)
        {
            var reports = GetReportsList(filter, sorting, currentPage, pageSize);

            return reports;
        }

        private List<Report> GetReportsList(string filter, string sorting, int currentPage, int pageSize)
        {
            var filterValues = filter.Split(';');
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);

            IQueryable<Report> query;

            using (var dbContext = new Context())
            {
                query = dbContext.Reports;

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
                "StartDate" => filArray[1] != " " ? query.Where(ani => ani.StartDate.ToLongDateString().Contains(filArray[1])) : query,
                "EndDate" => filArray[1] != " " ? query.Where(ani => ani.EndDate.ToLongDateString().Contains(filArray[1])) : query,
                "Creator" => filArray[1] != " " ? query.Where(ani => ani.Creator.Name.Contains(filArray[1])) : query,
                "Status" => filArray[1] != " " ? query.Where(ani => ani.Status.Contains(filArray[1])) : query,
                "StatusDate" => filArray[1] != " " ? query.Where(ani => ani.StatusDate.ToLongDateString().Contains(filArray[1])) : query,
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
                return dbContext.Reports.First(p => p.Id == id);
            }
        }

        public void Add(Report report)
        {
            using (var dbContext = new Context())
            {
                dbContext.Reports.Add(report);
                dbContext.SaveChanges();
            }
        }

        public void Update(Report report)
        {
            using (var dbContext = new Context())
            {
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
    }
}
