using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;
using MedicalExamination.Data;

namespace MedicalExamination.Services
{
    public class StatisticsService
    {
        public Statistics GetStatistics(DateTime from, DateTime to)
        {
            var privilege = new PrivilegeService().SetPrivilegeForUser();
            var localities = new LocalityRepository().GetLocalities(privilege);
            var statistics = new Statistics(from, to);
            foreach (var locality in localities)
            {
                var statLoc = new StatistictsLocality(locality);
                var linesData = new ExaminationRepository().GetLinesData(from, to, locality);
                foreach (var lineData in linesData)
                {
                    var line = new Line(lineData.Item1, lineData.Item2, lineData.Item3);
                    AddLine(statLoc, line);
                }
                CalculateCost(statLoc);
                AddStatisticsLocality(statistics, statLoc);
            }
            CalculateTotalCost(statistics);
            return statistics;
        }

        private void AddLine(StatistictsLocality statLoc, Line line)
        {
            statLoc.Lines.Add(line);
        }

        private void CalculateCost(StatistictsLocality statLoc)
        {
            foreach (var line in statLoc.Lines)
            {
                statLoc.Cost += line.Price;
            }
        }

        private void AddStatisticsLocality(Statistics statistics, StatistictsLocality statLoc)
        {
            statistics.StatistictsLocalities.Add(statLoc);
        }

        private void CalculateTotalCost(Statistics statistics)
        {
            foreach (var statLoc in statistics.StatistictsLocalities)
            {
                statistics.TotalCost += statLoc.Cost;
            }
        }
    }
}
