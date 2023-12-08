namespace ServerME.ViewModels
{
    public class ReportView
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organization { get; set; }
        public string Creator { get; set; }
        public List<string[]> File { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public ReportView()
        {

        }
        public ReportView(int id, DateTime startDate, DateTime endDate, string org, string creator, List<string[]> file, string status, DateTime statusDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Organization = org;
            Creator = creator;
            File = file;
            Status = status;
            StatusDate = statusDate;
        }

    }
}
