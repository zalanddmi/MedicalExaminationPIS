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
        public DateTime From;
        public DateTime To;
        public List<StatistictsLocality> StatistictsLocalities;
        public Statistics (DateTime from, DateTime to)
        {
            TotalCost = 0;
            From = from;
            To = to;
            StatistictsLocalities = new List<StatistictsLocality>();
        }

        public override bool Equals(object obj)
        {
            if (obj is Statistics stat)
            {
                if (TotalCost.Equals(stat.TotalCost) && From.Equals(stat.From) && To.Equals(stat.To)
                    && StatistictsLocalities.SequenceEqual(stat.StatistictsLocalities))
                {
                    return true;
                }
            }
            return false;
        }
    }
    public class Line
    {
        public string Diagnosis;
        public int Count;
        public double Price;

        public Line (string diagnosis, int count, double price)
        {
            Diagnosis = diagnosis;
            Count = count;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj is Line line)
            {
                if (Diagnosis.Equals(line.Diagnosis) && Count.Equals(line.Count) && Price.Equals(line.Price))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class StatistictsLocality
    {
        public double Cost;
        public Locality Locality;
        public List<Line> Lines;

        public StatistictsLocality (Locality locality)
        {
            Cost = 0;
            Locality = locality;
            Lines = new List<Line>();
        }

        public override bool Equals(object obj)
        {
            if (obj is StatistictsLocality statLoc)
            {
                if (Cost.Equals(statLoc.Cost) && Locality.Equals(statLoc.Locality) && Lines.SequenceEqual(statLoc.Lines))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
