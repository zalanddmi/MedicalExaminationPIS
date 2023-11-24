using ServerME.Data;
using ServerME.Models;
using ServerME.Utils;
using System.Collections;

namespace ServerME.Services
{
    public class LogService
    {
        private LogRepository repository;
        public LogService()
        {
            repository = new LogRepository();
        }
        public List<string[]> GetLogs(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = new Dictionary<string, string>();
            
            var logs = repository.GetAnimals(filter, sorting, privilege, currentPage, pageSize);
            var mappedLogs = MapLogs(logs);
            return mappedLogs;
        }

        private List<string[]> MapLogs(IEnumerable<Log> logs)
        {
            var result = new List<string[]>();
            foreach (var log in logs)
            {
                var temp = new string[]
                {
                    log.Id.ToString(),
                    log.Operation,
                    log.FullName,
                    log.Number,
                    log.Email,
                    log.Organization,
                    log.StructuralDivision,
                    log.Post,         
                    log.WorkNumber,      
                    log.WorkEmail,       
                    log.Login,           
                    log.Date.ToString(),            
                    log.NameObject,      
                    log.IdObject,        
                    log.DescriptionObject,  
                    log.FileNames          
                };
                result.Add(temp);
            }
            return result;
        }

        public void DeleteLogs(IEnumerable<int> logsIdArray, User user)
        {
            repository.DeleteLogs(logsIdArray);
        }
    }
}
