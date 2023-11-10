using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.ViewModels
{
    public class StatisticView
    {
        public double TotalCost;
        public DateTime From;
        public DateTime To;
        public List<(double, string, List<(string, int, double)>)> StatistictsLocalities;

        public StatisticView()
        {

        }
        
        public StatisticView(double totalCost, DateTime from, DateTime to,
            List<(double, string, List<(string, int, double)>)> statisticsLocalities)
        {
            TotalCost = totalCost;
            From = from;
            To = to;
            StatistictsLocalities = statisticsLocalities;
        }
    }
}
