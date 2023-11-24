using Microsoft.EntityFrameworkCore;
using ServerME.Utils;
using ServerME.Enums;

namespace ServerME.Data
{
    public class LogRepository
    {
        public List<Log> GetAnimals(string filter, string sorting,
            Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var logs = GetLogsList(filter, sorting, privilege, currentPage, pageSize);

            return logs;
        }

        private List<Log> GetLogsList(string filter, string sorting,
    Dictionary<string, string> privilege, int currentPage, int pageSize)
        {
            var filterValues = filter.Split(';');
            var sortValuesAll = sorting.Split(';');
            string[] sortValues = new string[sortValuesAll.Length - 1];
            Array.Copy(sortValuesAll, sortValues, sortValuesAll.Length - 1);

            IQueryable<Log> logsQuery;

            using (var dbContext = new Context())
            {
                logsQuery = dbContext.Logs;
                
                foreach (var fil in filterValues)
                {
                    var filArray = fil.Split('=');
                    logsQuery = ApplyFilter(logsQuery, filArray);
                }

                foreach (var sort in sortValues)
                {
                    var sortArray = sort.Split('=');
                    logsQuery = ApplySorting(logsQuery, sortArray);
                }

                return logsQuery
                    .Skip((currentPage - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }
        }

        private IQueryable<Log> ApplyFilter(IQueryable<Log> logsQuery, string[] filArray)
        {
            return filArray[0] switch
            {
                "Operation" => filArray[1] != " " ? logsQuery.Where(ani => ani.Operation.Contains(filArray[1])) : logsQuery,
                "FullName" => filArray[1] != " " ? logsQuery.Where(ani => ani.FullName.Contains(filArray[1])) : logsQuery,
                "Number" => filArray[1] != " " ? logsQuery.Where(ani => ani.Number.Contains(filArray[1])) : logsQuery,
                "Email" => filArray[1] != " " ? logsQuery.Where(ani => ani.Email.Contains(filArray[1])) : logsQuery,
                "Organization" => filArray[1] != " " ? logsQuery.Where(ani => ani.Organization.Contains(filArray[1])) : logsQuery,
                "StructuralDivision" => filArray[1] != " " ? logsQuery.Where(ani => ani.StructuralDivision.Contains(filArray[1])) : logsQuery,
                "Post" => filArray[1] != " " ? logsQuery.Where(ani => ani.Post.Contains(filArray[1])) : logsQuery,
                "WorkNumber" => filArray[1] != " " ? logsQuery.Where(ani => ani.WorkNumber.Contains(filArray[1])) : logsQuery,
                "WorkEmail" => filArray[1] != " " ? logsQuery.Where(ani => ani.WorkEmail.Contains(filArray[1])) : logsQuery,
                "Login" => filArray[1] != " " ? logsQuery.Where(ani => ani.Login.Contains(filArray[1])) : logsQuery,
                "Date" => filArray[1] != " " ? logsQuery.Where(ani => ani.Date.ToLongDateString().Contains(filArray[1])) : logsQuery,
                "NameObject" => filArray[1] != " " ? logsQuery.Where(ani => ani.NameObject.Contains(filArray[1])) : logsQuery,
                "IdObject" => filArray[1] != " " ? logsQuery.Where(ani => ani.IdObject.Contains(filArray[1])) : logsQuery,
                "DescriptionObject" => filArray[1] != " " ? logsQuery.Where(ani => ani.DescriptionObject.Contains(filArray[1])) : logsQuery,
                "FileNames" => filArray[1] != " " ? logsQuery.Where(ani => ani.FileNames.Contains(filArray[1])) : logsQuery,
                _ => logsQuery,
            };
        }

        private IQueryable<Log> ApplySorting(IQueryable<Log> logsQuery, string[] sortArray)
        {
            var sortDirection = (SortDirection)Enum.Parse(typeof(SortDirection), sortArray[1]);
            return sortArray[0] switch
            {
                "Operation" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Operation) : logsQuery.OrderByDescending(ani => ani.Operation),
                "FullName" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.FullName) : logsQuery.OrderByDescending(ani => ani.FullName),
                "Number" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Number) : logsQuery.OrderByDescending(ani => ani.Number),
                "Email" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Email) : logsQuery.OrderByDescending(ani => ani.Email),
                "Organization" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Organization) : logsQuery.OrderByDescending(ani => ani.Organization),
                "StructuralDivision" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.StructuralDivision) : logsQuery.OrderByDescending(ani => ani.StructuralDivision),
                "Post" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Post) : logsQuery.OrderByDescending(ani => ani.Post),
                "WorkNumber" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.WorkNumber) : logsQuery.OrderByDescending(ani => ani.WorkNumber),
                "WorkEmail" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.WorkEmail) : logsQuery.OrderByDescending(ani => ani.WorkEmail),
                "Login" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Login) : logsQuery.OrderByDescending(ani => ani.Login),
                "Date" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.Date) : logsQuery.OrderByDescending(ani => ani.Date),
                "NameObject" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.NameObject) : logsQuery.OrderByDescending(ani => ani.NameObject),
                "IdObject" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.IdObject) : logsQuery.OrderByDescending(ani => ani.IdObject),
                "DescriptionObject" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.DescriptionObject) : logsQuery.OrderByDescending(ani => ani.DescriptionObject),
                "FileNames" => sortDirection == SortDirection.Ascending ? logsQuery.OrderBy(ani => ani.FileNames) : logsQuery.OrderByDescending(ani => ani.FileNames),
                _ => logsQuery,
            };
        }

        public void Add(Log log)
        {
            using (var dbContext = new Context())
            {
                dbContext.Logs.Add(log);
                dbContext.SaveChanges();
            }
        }

        public void AddRange(List<Log> logList)
        {
            using (var dbContext = new Context())
            {
                dbContext.Logs.AddRange(logList);
                dbContext.SaveChanges();
            }
        }

        public void DeleteLogs(IEnumerable<int> logsIdArray)
        {
            using (var dbContext = new Context())
            {
                foreach (var id in logsIdArray)
                {
                    dbContext.Logs.Where(p => p.Id == id).ExecuteDelete();
                }                
            }
        }
    }
}
