namespace ServerME.Models
{
    public class Report
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User Creator { get; set; }
        public string FilePath { get; set; }
        public string Status { get; set; }
        public DateTime StatusDate { get; set; }
        public Report()
        {

        }
    }
}