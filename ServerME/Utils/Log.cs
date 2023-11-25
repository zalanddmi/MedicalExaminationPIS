namespace ServerME.Utils
{
    public class Log
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string FullName { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Organization { get; set; }
        public string StructuralDivision { get; set; } = string.Empty;
        public string Post { get; set; }
        public string WorkNumber { get; set; } = string.Empty;
        public string WorkEmail { get; set; } = string.Empty;
        public string Login { get; set; }
        public DateTime Date { get; set; }
        public string NameObject { get; set; }
        public string IdObject { get; set; }
        public string DescriptionObject { get; set; }
        public string FileNames { get; set; }
        public Log()
        {

        }
        public Log(string operation, string fullName, string organization, string post, string login, DateTime date, string nameObject, string idObject, string descriptionObject, string fileNames)
        {
            Operation = operation;
            FullName = fullName;
            Organization = organization;
            Post = post;
            Login = login;
            Date = date;
            NameObject = nameObject;
            IdObject = idObject;
            DescriptionObject = descriptionObject;
            FileNames = fileNames;
        }
    }
}