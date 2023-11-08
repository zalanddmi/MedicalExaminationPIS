using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Models;
using ServerME.Data;

namespace ServerME.Services
{
    public class StatisticsService
    {
        public PrivilegeService _privilegeSerivce = new PrivilegeService();
        public LocalityRepository _localityRepository = new LocalityRepository();
        public ExaminationRepository _examinationService = new ExaminationRepository();

        public Statistics GetStatistics(DateTime from, DateTime to, User user)
        {
            var privilege = _privilegeSerivce.SetPrivilegeForUser(user);
            var localities = _localityRepository.GetLocalities(privilege);
            var statistics = new Statistics(from, to);
            foreach (var locality in localities)
            {
                var statLoc = GetStatistictsLocality(locality, from, to);
                AddStatisticsLocality(statistics, statLoc);
            }
            CalculateTotalCost(statistics);
            return statistics;
        }

        public StatistictsLocality GetStatistictsLocality(Locality locality, DateTime from, DateTime to)
        {
            var statLoc = new StatistictsLocality(locality);
            var linesData = _examinationService.GetLinesData(from, to, locality);
            foreach (var lineData in linesData)
            {
                var line = new Line(lineData.Item1, lineData.Item2, lineData.Item3);
                AddLine(statLoc, line);
            }
            CalculateCost(statLoc);
            return statLoc;
        }

        public void AddLine(StatistictsLocality statLoc, Line line)
        {
            statLoc.Lines.Add(line);
        }

        public void CalculateCost(StatistictsLocality statLoc)
        {
            foreach (var line in statLoc.Lines)
            {
                statLoc.Cost += line.Price;
            }
        }

        public void AddStatisticsLocality(Statistics statistics, StatistictsLocality statLoc)
        {
            statistics.StatistictsLocalities.Add(statLoc);
        }

        public void CalculateTotalCost(Statistics statistics)
        {
            foreach (var statLoc in statistics.StatistictsLocalities)
            {
                statistics.TotalCost += statLoc.Cost;
            }
        }
    }
}
