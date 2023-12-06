using ServerME.Data;
using ServerME.Models;

namespace ServerME.Services
{
    public class ReportService
    {
        private ReportRepository repository;
        private PrivilegeService privilegeService;
        public ReportService()
        {
            repository = new ReportRepository();
            privilegeService = new PrivilegeService();
        }

        public List<string[]> GetReports(string filter, string sorting, int currentPage, int pageSize)
        {
            //var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotReports = repository.GetReports(filter, sorting, currentPage, pageSize);
            var reports = MapReports(gotReports);
            return reports;
        }

        private List<string[]> MapReports(IEnumerable<Report> gotReports)
        {
            var result = new List<string[]>();
            foreach (var report in gotReports)
            {
                result.Add(
                    new string[]
                    {
                        report.Id.ToString(),
                        report.StartDate.ToShortDateString(),
                        report.EndDate.ToShortDateString(),
                        report.Creator.Name,
                        report.Status,
                        report.StatusDate.ToShortDateString()
                    }
                );
            }
            return result;
        }

    }
}
