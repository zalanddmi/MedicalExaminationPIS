using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Models
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

        //.net core жалуется, что obj должен поддерживать null!!! (ПЕРЕПРОВЕРИТЬ, ЧТОБЫ БУДЕТ ВО ВРЕМЯ ТЕСТИРОВАНИЯ)
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
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

        //.net core жалуется, что obj должен поддерживать null!!! (ПЕРЕПРОВЕРИТЬ, ЧТОБЫ БУДЕТ ВО ВРЕМЯ ТЕСТИРОВАНИЯ)
        public override int GetHashCode()
        {
            throw new NotImplementedException();
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

        //.net core жалуется, что obj должен поддерживать null!!! (ПЕРЕПРОВЕРИТЬ, ЧТОБЫ БУДЕТ ВО ВРЕМЯ ТЕСТИРОВАНИЯ)
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is Line line)
            {
                if (Diagnosis.Equals(line.Diagnosis) && Count.Equals(line.Count) && Price.Equals(line.Price))
                {
                    return true;
                }
            }
            return false;
        }

        //.net core дает ошибку, что Equals переопределен, а GetHashCode нет
        public override int GetHashCode()
        {
            throw new NotImplementedException();
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

        //.net core жалуется, что obj должен поддерживать null!!! (ПЕРЕПРОВЕРИТЬ, ЧТОБЫ БУДЕТ ВО ВРЕМЯ ТЕСТИРОВАНИЯ)
        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is StatistictsLocality statLoc)
            {
                if (Cost.Equals(statLoc.Cost) && Locality.Equals(statLoc.Locality) && Lines.SequenceEqual(statLoc.Lines))
                {
                    return true;
                }
            }
            return false;
        }
        

        //.net core дает ошибку, что Equals переопределен, а GetHashCode нет
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
