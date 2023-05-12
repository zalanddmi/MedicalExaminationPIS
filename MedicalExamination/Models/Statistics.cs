using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Statistics
    {
        public string ItogCount;
        public DateTime DateBegin;
        public DateTime DateCompletion;
        public Line Line;
        public Statistics (string itogCount, DateTime dateBegin, DateTime dateCompletion, Line line)
        {
            ItogCount = itogCount;
            DateBegin = dateBegin;
            DateCompletion = dateCompletion;
            Line = line;
        }
    }
    public class Line
    {
        public string Damage;
        public int Count;
        public string Price;
        public StatistictsLocality StatistictsLocality;
        public Line ( string damage, int count, string price, StatistictsLocality statistictsLocality)
        {
            Damage = damage;
            Count = count;
            Price = price;
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
