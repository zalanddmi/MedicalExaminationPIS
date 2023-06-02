using MedicalExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Data
{
    public class ExaminationRepository
    {
        public void AddExamination(Examination examination)
        {
            var maxId = TestData.Examinations.Max(ex => ex.IdExamination);
            examination.IdExamination = maxId + 1;
            TestData.Examinations.Add(examination);
        }

        public Tuple<string, int, double>[] GetLinesData(DateTime from, DateTime to, Locality locality)
        {
            var result = TestData.Examinations
                        .Join(TestData.Costs,
                              e => e.MunicipalContract.IdMunicipalContract,
                              c => c.MunicipalContract.IdMunicipalContract,
                              (e, c) => new { Examination = e, Cost = c })
                        .Where(ec => ec.Examination.DateExamination >= from
                                     && ec.Examination.DateExamination <= to
                                     && ec.Cost.Locality == locality)
                        .GroupBy(ec => ec.Examination.Diagnosis)
                        .Select(g => new Tuple<string, int, double>(
                            g.Key,
                            g.Count(),
                            g.Sum(ec => ec.Cost.Value)
                        ))
                        .ToArray();
            return result;
        }
    }
}
