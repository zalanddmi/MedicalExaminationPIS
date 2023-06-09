using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using MedicalExamination.Services;
using MedicalExamination.Data;
using MedicalExamination.Models; 

namespace MedicalExamination.Tests
{
    public class TestPrivilegeService : PrivilegeService
    {
        public Dictionary<string, string> Privilege { get; set; }
        public override Dictionary<string, string> SetPrivilegeForUser()
        {
            return Privilege;
        }
    }

    public class TestLocalityRepository : LocalityRepository
    {
        public List<Locality> Localities { get; set; }
        public override List<Locality> GetLocalities(Dictionary<string, string> privilege)
        {
            return Localities;
        }
    }

    public class TestExaminationRepository : ExaminationRepository
    {
        public Tuple<string, int, double>[] LinesData { get; set; }
        public override Tuple<string, int, double>[] GetLinesData(DateTime from, DateTime to, Locality locality)
        {
            return LinesData;
        }
    }

    [TestFixture]
    public class StatisticsTest
    {
        private StatisticsService _statisticsService;

        private TestPrivilegeService _privilegeServiceTest;
        private TestLocalityRepository _localityRepositoryTest;
        private TestExaminationRepository _examinationRepositoryTest;

        [SetUp]
        public void SetUp()
        {
            _privilegeServiceTest = new TestPrivilegeService();
            _localityRepositoryTest = new TestLocalityRepository();
            _examinationRepositoryTest = new TestExaminationRepository();

            _statisticsService = new StatisticsService()
            {
                _privilegeSerivce = _privilegeServiceTest,
                _localityRepository = _localityRepositoryTest,
                _examinationService = _examinationRepositoryTest
            };
        }

        [Test]
        public void GetStatistics_First()
        {
            //Arrange
            var from = new DateTime(2023, 1, 1);
            var to = new DateTime(2023, 1, 31);
            var privilege = new Dictionary<string, string> { { "Statistics", "Mun=5;Mun=5" } };
            var localities = new List<Locality> { new Locality(5, "Тобольск", new Municipality(5, "ГО город Тобольск")) };
            var linesData = new Tuple<string, int, double>[] { Tuple.Create("Перелом", 10, 1000.0), Tuple.Create("Бешенство", 5, 1100.0) };
            _privilegeServiceTest.Privilege = privilege;
            _localityRepositoryTest.Localities = localities;
            _examinationRepositoryTest.LinesData = linesData;
            //Act
            var statistics = _statisticsService.GetStatistics(from, to);
            //Assert
            var statisticsExpected = new Statistics(from, to)
            {
                TotalCost = 2100,
                StatistictsLocalities = new List<StatistictsLocality>
                {
                    new StatistictsLocality(localities[0])
                    {
                        Cost = 2100,
                        Lines = new List<Line>
                        {
                            new Line("Перелом", 10, 1000),
                            new Line("Бешенство", 5, 1100)
                        }
                    }
                }
            };
            Assert.AreEqual(statisticsExpected, statistics);
        }

        [Test]
        public void GetStatistics_WithValidData_ReturnsCorrectStatistics()
        {
            // Arrange
            var from = new DateTime(2023, 1, 1);
            var to = new DateTime(2023, 1, 31);
            var privilege = new Dictionary<string, string> { { "Statistics", "Mun=5;Mun=5" } };
            var localities = new List<Locality>
            {
                new Locality(1, "Тобольск", new Municipality(5, "ГО город Тобольск")),
            };
            var linesData = new Tuple<string, int, double>[]
            {
                Tuple.Create("Перелом", 10, 1000.0),
                Tuple.Create("Бешенство", 5, 1100.0)
            };
            _privilegeServiceTest.Privilege = privilege;
            _localityRepositoryTest.Localities = localities;
            _examinationRepositoryTest.LinesData = linesData;
            // Act
            var statistics = _statisticsService.GetStatistics(from, to);
            // Assert
            Assert.IsNotNull(statistics);
            Assert.AreEqual(from, statistics.From);
            Assert.AreEqual(to, statistics.To);
            Assert.AreEqual(2100, statistics.TotalCost);
            Assert.AreEqual(1, statistics.StatistictsLocalities.Count);
            Assert.AreEqual(localities[0], statistics.StatistictsLocalities[0].Locality);
            Assert.AreEqual(2100, statistics.StatistictsLocalities[0].Cost);
            Assert.AreEqual(2, statistics.StatistictsLocalities[0].Lines.Count);
            Assert.AreEqual("Перелом", statistics.StatistictsLocalities[0].Lines[0].Diagnosis);
            Assert.AreEqual(10, statistics.StatistictsLocalities[0].Lines[0].Count);
            Assert.AreEqual(1000, statistics.StatistictsLocalities[0].Lines[0].Price);
            Assert.AreEqual("Бешенство", statistics.StatistictsLocalities[0].Lines[1].Diagnosis);
            Assert.AreEqual(5, statistics.StatistictsLocalities[0].Lines[1].Count);
            Assert.AreEqual(1100, statistics.StatistictsLocalities[0].Lines[1].Price);
        }

        [Test]
        public void GetStatistics_WithEmptyLocalitiesAndLinesData_ReturnsEmptyStatistics()
        {
            // Arrange
            var from = new DateTime(2023, 1, 1);
            var to = new DateTime(2023, 1, 31);
            var privilege = new Dictionary<string, string> { { "Animals", "All;All" } };
            var localities = new List<Locality>();
            var linesData = new Tuple<string, int, double>[0];
            _privilegeServiceTest.Privilege = privilege;
            _localityRepositoryTest.Localities = localities;
            _examinationRepositoryTest.LinesData = linesData;
            // Act
            var statistics = _statisticsService.GetStatistics(from, to);
            // Assert
            Assert.IsNotNull(statistics);
            Assert.AreEqual(from, statistics.From);
            Assert.AreEqual(to, statistics.To);
            Assert.AreEqual(0, statistics.TotalCost);
            Assert.IsEmpty(statistics.StatistictsLocalities);
        }

        [Test]
        public void GetStatistics_WithEmptyLinesData_ReturnsEmptyStatistics()
        {
            // Arrange
            var from = new DateTime(2023, 1, 1);
            var to = new DateTime(2023, 1, 31);
            var privilege = new Dictionary<string, string> { { "Statistics", "Mun=5;Mun=5" } };
            var localities = new List<Locality>
            {
                new Locality(1, "Тобольск", new Municipality(5, "ГО город Тобольск")),
            };
            var linesData = new Tuple<string, int, double>[0];
            _privilegeServiceTest.Privilege = privilege;
            _localityRepositoryTest.Localities = localities;
            _examinationRepositoryTest.LinesData = linesData;
            // Act
            var statistics = _statisticsService.GetStatistics(from, to);
            // Assert
            Assert.IsNotNull(statistics);
            Assert.AreEqual(from, statistics.From);
            Assert.AreEqual(to, statistics.To);
            Assert.AreEqual(0, statistics.TotalCost);
            Assert.AreEqual(1, statistics.StatistictsLocalities.Count);
            Assert.AreEqual(localities[0], statistics.StatistictsLocalities[0].Locality);
            Assert.AreEqual(0, statistics.StatistictsLocalities[0].Cost);
            Assert.AreEqual(0, statistics.StatistictsLocalities[0].Lines.Count);
        }

    }
}
