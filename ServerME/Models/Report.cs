namespace ServerME.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Organization Organization { get; set; }
        public User Creator { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public Report()
        {

        }
        public Report(DateTime startDate, DateTime endDate, Organization organization, User creator, string filePath, string status, DateTime statusDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Organization = organization;
            Creator = creator;
            FilePath = filePath;
            Status = status;
            StatusDate = statusDate;
        }
        public Report(int id, DateTime startDate, DateTime endDate, Organization organization, User creator, string filePath, string status, DateTime statusDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Organization = organization;
            Creator = creator;
            FilePath = filePath;
            Status = status;
            StatusDate = statusDate;
        }
    }
}
