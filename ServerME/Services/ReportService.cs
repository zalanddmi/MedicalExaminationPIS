
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Utils;
using ServerME.Data;
using ServerME.Models;
using ServerME.ViewModels;
using System.IO;

namespace ServerME.Services
{
    public class ReportService
    {
        private ReportRepository repository;
        private OrganizationsRepository organizationRepository;
        private PrivilegeService privilegeService;
        private StatisticsService statisticsService;
        string directory = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName + "\\Files";
        public ReportService()
        {
            repository = new ReportRepository();
            privilegeService = new PrivilegeService();
            organizationRepository = new OrganizationsRepository();
            statisticsService = new StatisticsService();
        }

        public List<string[]> GetReports(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotReports = repository.GetReports(filter, sorting, privilege, currentPage, pageSize);
            var reports = MapReports(gotReports, user);
            return reports;
        }

        public void DeleteReport(int reportId, User user)
        {
            repository.Delete(reportId);
        }

        private List<string[]> MapReports(IEnumerable<Report> gotReports, User user)
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
                        report.Organization.Name,
                        report.Creator.Name,
                        report.Status,
                        report.StatusDate.ToShortDateString(),
                        CanUpdateStatus(user, report.Status).ToString()
                    }
                );
            }
            return result;
        }

        public void UpdateReport(ReportView card, User user)
        {
            var report = new Report(card.Id, card.StartDate, card.EndDate, new Organization(), new User(), "", card.Status, card.StatusDate);
            repository.Update(report);
            SendMessage(user, report);
        }

        public List<string> GetStatusReport(User user) => repository.GetStatusReport(user);

        public void SaveReport(string from, string to, int organizationId, string status, User user)
        {
            var filePath = MakeExcel(from, to, organizationId, user);
            Console.WriteLine(filePath);
            var report = new Report(DateTime.Parse(from), DateTime.Parse(to), new Organization() { IdOrganization = organizationId }, new User() { IdUser = user.IdUser }, filePath, status, DateTime.Now);
            repository.Add(report);
        }

        private string MakeExcel(string from, string to, int organizationId, User user)
        {
            StatisticView statistics = statisticsService.GetStatisticsForOrganization(DateTime.Parse(from), DateTime.Parse(to), organizationId, user);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var exPac = new ExcelPackage();
            var worksheet = exPac.Workbook.Worksheets.Add("file");
            var columnNames = new string[] { "Диагноз", "Количество", "Стоимость" };
            for (int j = 0; j < columnNames.Length; j++)
            {
                worksheet.Cells[1, j + 1].Value = columnNames[j];
            }
            var statLoc = statistics.StatistictsLocalities[0];
            for (int i = 0; i < statLoc.Item3.Count; i++)
            {

                var line = statLoc.Item3[i];
                var values = new string[] { statLoc.Item2, line.Item1, line.Item2.ToString(), line.Item3.ToString() };
                Console.WriteLine(String.Join("|", values));
                worksheet.Cells[i + 2, 1].Value = line.Item1;
                worksheet.Cells[i + 2, 2].Value = line.Item2.ToString();
                worksheet.Cells[i + 2, 3].Value = line.Item3.ToString();

                worksheet.Cells[i + 2, 1].AutoFitColumns();
                worksheet.Cells[i + 2, 2].AutoFitColumns();
                worksheet.Cells[i + 2, 3].AutoFitColumns();
                worksheet.Cells[i + 2, 1].Style.WrapText = true;
                worksheet.Cells[i + 2, 2].Style.WrapText = true;
                worksheet.Cells[i + 2, 3].Style.WrapText = true;

            }
            worksheet.Cells[statLoc.Item3.Count + 2, 2].Value = "Итог";
            worksheet.Cells[statLoc.Item3.Count + 2, 3].Value = statLoc.Item1;
            var fileName = $"\\report{Guid.NewGuid()}.xlsx";
            File.WriteAllBytes(directory + fileName, exPac.GetAsByteArray());
            return fileName;
        }
       
        public ReportView GetReport(int id, User user)
        {
            var report = repository.Get(id);
            var view = MapReport(report);
            return view;
        }

        private ReportView MapReport(Report report)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var pac = new ExcelPackage(directory + report.FilePath);
            var worksheet = pac.Workbook.Worksheets[0];

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            var data = new List<string[]>();
            for (int i = 2; i <= rowCount; i++)
            {
                var temp = new List<string>();
                temp.Add("");
                for (int j = 1; j <= colCount; j++)
                {
                    string cellValue = worksheet.Cells[i, j].Text;
                    temp.Add(cellValue);
                }
                data.Add(temp.ToArray());
            }

            var view = new ReportView(report.Id, report.StartDate, report.EndDate, report.Organization.Name, report.Creator.Name, data, report.Status, report.StatusDate);
            return view;
        }

        private bool CanUpdateStatus(User user, string status)
        {
            return privilegeService.CheckUserForReport(status, user);
        }
        private void SendMessage(User user, Report report)
        {
            if (user.IdUser != report.Creator.IdUser)
            {
                Console.WriteLine($"{report.Creator.Name}\n{user.Post} - {user.Name} поменял статус вашего отчета на {report.Status}");
            }    
        }
    }
}
