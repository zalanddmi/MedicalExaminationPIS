using ServerME.Data;
using ServerME.Models;
using ServerME.Utils;
using System.Collections;

namespace ServerME.Services
{
    public class LogService
    {
        private LogRepository repository;
        private PrivilegeService privilegeService;
        public LogService()
        {
            repository = new LogRepository();
            privilegeService = new PrivilegeService();
        }
        public List<string[]> GetLogs(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var resultCheck = privilegeService.CheckUserForLogs(user);

            if (resultCheck)
            {
                var logs = repository.GetLogs(filter, sorting, currentPage, pageSize);
                var mappedLogs = MapLogs(logs);
                return mappedLogs;
            }
            else
            {
                throw new InvalidOperationException("У вас нет прав администрирования!");
            }
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

        public byte[] GetExcelByteArrayFormat(string filter, string sorting, User user)
        {
            var resultCheck = privilegeService.CheckUserForLogs(user);

            if (resultCheck)
            {
                string[] columnNames = new string[] {"Операция", "ФИО", "Телефон", "Эл. почта", "Организация",
                "Структурное подразделение", "Должность", "Раб. телефон", "Раб. адрес эл. почта",
                "Логин", "Дата и время", "Объект", "ID объекта",  "Описание объекта после совершения действия", "Загруженный файл"};

                var logs = GetLogs(filter, sorting, 1, int.MaxValue, user);
                return ExcelConverter.GenerateExcelFile(logs, columnNames);
            }
            else
            {
                throw new InvalidOperationException("У вас нет прав администрирования!");
            }
        }

        public void DeleteLogs(IEnumerable<int> logsIdArray, User user)
        {
            var resultCheck = privilegeService.CheckUserForLogs(user);

            if (resultCheck)
            {
                repository.DeleteLogs(logsIdArray);
            }
            else
            {
                throw new InvalidOperationException("У вас нет прав администрирования!");
            }
        }
    }
}
