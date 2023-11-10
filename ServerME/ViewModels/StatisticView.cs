namespace ServerME.ViewModels
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
