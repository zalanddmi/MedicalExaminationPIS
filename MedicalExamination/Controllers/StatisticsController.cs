using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Services;
using MedicalExamination.Models;

namespace MedicalExamination.Controllers
{
    public class StatisticsController
    {
        public Statistics GetStatistics(DateTime from, DateTime to)
        {
            return new StatisticsService().GetStatistics(from, to);
        }
    }
}
