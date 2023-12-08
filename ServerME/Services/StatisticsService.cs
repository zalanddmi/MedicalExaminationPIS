using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Models;
using ServerME.Data;
using ServerME.ViewModels;

namespace ServerME.Services
{
    public class StatisticsService
    {
        private PrivilegeService _privilegeSerivce = new PrivilegeService();
        private LocalityRepository _localityRepository = new LocalityRepository();
        private OrganizationsRepository _organizationRepository = new OrganizationsRepository();
        private ExaminationRepository _examinationService = new ExaminationRepository();

        public StatisticView GetStatistics(DateTime from, DateTime to, User user)
        {
            var privilege = _privilegeSerivce.SetPrivilegeForUser(user);
            var localities = _localityRepository.GetLocalitiesForStatistics(privilege);
            var statistics = new Statistics(from, to);
            foreach (var locality in localities)
            {
                var statLoc = GetStatistictsLocality(locality, from, to);
                AddStatisticsLocality(statistics, statLoc);
            }
            CalculateTotalCost(statistics);
            StatisticView statisticView = MapViewStatistic(statistics);
            return statisticView;
        }

        public StatisticView GetStatisticsForOrganization(DateTime from, DateTime to, int orgId, User user)
        {
            var privilege = _privilegeSerivce.SetPrivilegeForUser(user);

            var statistics = new Statistics(from, to);

            var statLoc = GetStatistictsLocality(from, to, orgId);
            AddStatisticsLocality(statistics, statLoc);

            CalculateTotalCost(statistics);
            StatisticView statisticView = MapViewStatistic(statistics);
            return statisticView;
        }
        public StatistictsLocality GetStatistictsLocality(DateTime from, DateTime to, int orgId)
        {
            var locality = _organizationRepository.GetOrganization(orgId).Locality;
            var statLoc = new StatistictsLocality(locality);
            var linesData = _examinationService.GetLinesData(from, to, locality, orgId);
            foreach (var lineData in linesData)
            {
                var line = new Line(lineData.Item1, lineData.Item2, lineData.Item3);
                AddLine(statLoc, line);
            }
            CalculateCost(statLoc);
            return statLoc;
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

        private StatisticView MapViewStatistic(Statistics statistics)
        {
            var statisticsLocalities = new List<(double, string, List<(string, int, double)>)>();
            foreach (var statLoc in statistics.StatistictsLocalities)
            {
                var lines = new List<(string, int, double)>();
                foreach (var line in statLoc.Lines)
                {
                    lines.Add((line.Diagnosis, line.Count, line.Price));
                }
                statisticsLocalities.Add((statLoc.Cost, statLoc.Locality.Name, lines));
            }
            StatisticView statisticView = new StatisticView(statistics.TotalCost, statistics.From, statistics.To, statisticsLocalities);
            return statisticView;
        }
    }
}
