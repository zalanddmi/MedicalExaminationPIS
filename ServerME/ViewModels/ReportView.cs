namespace ServerME.ViewModels
{
    public class ReportView
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Creator { get; set; }
        public Image File { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public ReportView()
        {

        }
    }
}
