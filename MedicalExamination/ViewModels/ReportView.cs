using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.ViewModels
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
        public ReportView(DateTime startDate, DateTime endDate, string creator, Image file, string status, DateTime statusDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            Creator = creator;
            File = file;    
            Status = status;
            StatusDate = statusDate;
        }
        public ReportView(int id, DateTime startDate, DateTime endDate, string creator, Image file, string status, DateTime statusDate)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Creator = creator;
            File = file;
            Status = status;
            StatusDate = statusDate;
        }

    }
}
