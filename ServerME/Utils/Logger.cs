using ServerME.Models;
using ServerME.Data;
using System.Reflection;

namespace ServerME.Utils
{ 
    public class Logger<TValue> where TValue : class
    {
        private LogRepository repository;
        private PropertyInfo propId;
        private PropertyInfo? propPhotos;
        private PropertyInfo? propScan;
        private MethodInfo toString;
        private MethodInfo equals;
        private string objectName;
        public Logger()
        {
            repository = new LogRepository();
            var type = typeof(TValue);

            propId = type.GetProperties().First();
            propPhotos = type.GetProperty("Photos");
            propScan = type.GetProperty("Scan");
            toString = type.GetMethod("ToString");
            equals = type.GetMethod("Equals");
            objectName = type.Name;

        }

        public void LogAdding(User user, TValue obj)
        {
            var id = propId.GetValue(obj).ToString();
            var objectDescription = toString.Invoke(obj, new object[] { }).ToString();
            Log(user, "Добавить", id, objectDescription, string.Empty);
            if (propPhotos is not null)
            {
                var list = (IEnumerable<string>)propPhotos.GetValue(obj);
                LogImage(user, "Загрузить файл", id, list);
            }
            if (propScan is not null)
            {
                var list = (IEnumerable<string>)propScan.GetValue(obj);
                LogImage(user, "Загрузить файл", id, list);
            }
        }
        public void LogUpdating(User user, TValue value, TValue updatedValue)
        {
            var id = propId.GetValue(updatedValue).ToString();
            if (!Convert.ToBoolean(equals.Invoke(value, new object[] {updatedValue})))
            {
                var objectDescription = toString.Invoke(updatedValue, new object[] { }).ToString();
                Log(user, "Изменить", id, objectDescription, string.Empty);
            }
            if (propPhotos is not null)
            {
                LogFile(user, value, updatedValue, id, propPhotos);
            }
            if (propScan is not null)
            {
                LogFile(user, value, updatedValue, id, propScan);
            }
        }
        public void LogRemoving(User user, int id)
        {
            Log(user, "Удалить", id.ToString(), "Объект удален", string.Empty);
        }

        private void LogFile(User user, TValue value, TValue updatedValue, string id, PropertyInfo property)
        {
            var list = (IEnumerable<string>)property.GetValue(value);
            var updatedList = (IEnumerable<string>)property.GetValue(updatedValue);

            LogImage(user, "Загрузить файл", id, updatedList.Except(list));
            LogImage(user, "Удалить файл", id, list.Except(updatedList));
        }
        public void LogImage(User user, string operation, string id, IEnumerable<string> fileNames)
        {
            List<Log> logList = new List<Log>();
            foreach (var fileName in fileNames)
            {
                Log log = new Log(
                operation,
                user.Name,
                user.Organization.Name,
                user.Post,
                user.Login,
                DateTime.Now,
                objectName,
                id,
                string.Empty,
                fileName
                );
                logList.Add(log);
            }
            repository.AddRange(logList);
        }
        private void Log(User user, string operation, string id, string objectDescription, string fileName)
        {
            Log log = new Log(
            operation,
            user.Name,
            user.Organization.Name,
            user.Post,
            user.Login,
            DateTime.Now,
            objectName,
            id,
            objectDescription,
            fileName
            );
            repository.Add(log);
        }             
    }
}
