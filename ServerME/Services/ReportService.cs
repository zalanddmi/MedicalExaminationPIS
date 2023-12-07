using Microsoft.AspNetCore.Mvc;
using ServerME.Data;
using ServerME.Models;
using ServerME.ViewModels;
using System.IO;

namespace ServerME.Services
{
    public class ReportService
    {
        private ReportRepository repository;
        private PrivilegeService privilegeService;
        string directory = new DirectoryInfo(Directory.GetCurrentDirectory()).FullName + "\\Files";
        public ReportService()
        {
            repository = new ReportRepository();
            privilegeService = new PrivilegeService();
        }

        public List<string[]> GetReports(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            //var privilege = privilegeService.SetPrivilegeForUser(user);
            var gotReports = repository.GetReports(filter, sorting, currentPage, pageSize);
            var reports = MapReports(gotReports);
            return reports;
        }

        public void DeleteReport(int reportId, User user)
        {
            repository.Delete(reportId);
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

        public void UpdateReport(ReportView card, User user)
        {
            repository.Update(new Report(card.Id, card.StartDate, card.EndDate, new User(), card.File.filePath, card.Status, card.StatusDate));
        }
        private List<string> SaveFile(List<ViewModels.Image> photos)
        {
            List<string> pathPhoto = new List<string>();
            foreach (var photo in photos)
            {
                //удаление фотки и сохранение старой
                var filePath = directory + photo.filePath;
                if (photo.filePath != null && File.Exists(filePath))
                {
                    if (photo.data == null)
                    {
                        File.Delete(filePath);
                        continue;
                    }
                    pathPhoto.Add(photo.filePath);
                    continue;
                }
                if (photo.data == null)
                    continue;


                //сохранение новой фотки
                var fileName = $"\\photo{Guid.NewGuid()}.png";
                File.WriteAllBytes(directory + fileName, photo.data);


                pathPhoto.Add(fileName);
            }
            return pathPhoto;
        }

        public void SaveReport(string from, string to, string status, User user)
        {
            throw new NotImplementedException();
        }
    }
}
