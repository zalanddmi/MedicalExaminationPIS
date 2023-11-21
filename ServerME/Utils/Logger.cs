using ServerME.Models;
using ServerME.Data;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ServerME.Utils
{ 
    public class Logger
    {
        private LogRepository repository;
        public Logger()
        {
            repository = new LogRepository();
        }
        public void LogAnimalAdding(User user, Animal animal)
        {
            Log log = new Log(
            "Добавление",
            user.Name,
            user.Organization.Name,
            user.Post,
            user.Login,
            DateTime.Now,
            "Животное",
            animal.IdAnimal.ToString(),
            animal.ToString(),
            String.Empty
            );
            repository.Add(log);
        }

        public void LogAnimalUpdating(User user, Animal animal, Animal updatedAnimal)
        {
            if (!animal.Equals(updatedAnimal))
            {
                Log log = new Log(
                "Обновление",
                user.Name,
                user.Organization.Name,
                user.Post,
                user.Login,
                DateTime.Now,
                "Животное",
                animal.IdAnimal.ToString(),
                animal.ToString(),
                String.Empty
                );
                repository.Add(log);
            }
                
        }
        public void LogAnimalRemoving(User user, int id)
        {
            Log log = new(
            "Удаление",
            user.Name,
            user.Organization.Name,
            user.Post,
            user.Login,
            DateTime.Now,
            "Животное",
            id.ToString(),
            "Объект удален!",
            String.Empty
            );
            repository.Add(log);
        }
        public void LogAnimalImageAdding(User user, int idAnimal, IEnumerable<string> fileNames)
        {
            List<Log> logList = new List<Log>();
            foreach (var fileName in fileNames)
            {
                Log log = new Log(
                "Добавление",
                user.Name,
                user.Organization.Name,
                user.Post,
                user.Login,
                DateTime.Now,
                "Животное",
                idAnimal.ToString(),
                "Добавление фотографии",
                fileName
                );
                logList.Add(log);
            }
            repository.AddRange(logList);
        }
        public void LogAnimalImageRemoving(User user,int idAnimal, IEnumerable<string> fileNames)
        {
            List<Log> logList = new List<Log>();
            foreach (var fileName in fileNames)
            {
                Log log = new Log(
                "Удаление",
                user.Name,
                user.Organization.Name,
                user.Post,
                user.Login,
                DateTime.Now,
                "Животное",
                idAnimal.ToString(),
                "Удаление фотографии",
                fileName
                );
                logList.Add(log);
            }
            repository.AddRange(logList);
        }
    }
}
