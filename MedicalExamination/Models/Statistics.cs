using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Statistics
    {
        public double TotalCost;
        public DateTime DateBegin;
        public DateTime DateCompletion;
        public Statistics (double totalCost, DateTime dateBegin, DateTime dateCompletion)
        {
            TotalCost = totalCost;
            DateBegin = dateBegin;
            DateCompletion = dateCompletion;
        }
    }
    public class Line
    {
        public string Diagnosis;
        public int Count;
        public double Price;
        public Statistics Statistics;
        public StatistictsLocality StatistictsLocality;
        public Line (string diagnosis, int count, double price, Statistics statistics, StatistictsLocality statistictsLocality)
        {
            Diagnosis = diagnosis;
            Count = count;
            Price = price;
            Statistics = statistics;
            StatistictsLocality = statistictsLocality;
        }
    }
    public class StatistictsLocality
    {
        public string Cost;
        public Locality Locality;
        public StatistictsLocality (string cost, Locality locality)
        {
            Cost = cost;
            Locality = locality;
        }
    }
}
