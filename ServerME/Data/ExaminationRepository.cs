using Microsoft.EntityFrameworkCore;
using ServerME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Data
{
    public class ExaminationRepository
    {
        public void AddExamination(Examination examination)
        {
            using (var dbContext = new Context())
	        {
                dbContext.Examinations.Add(examination);
                dbContext.SaveChanges();
	        }
        }

        public virtual Tuple<string, int, double>[] GetLinesData(DateTime from, DateTime to, Locality locality)
        {
            var examinations = new List<Examination>();
            var costs = new List<Cost>();

            using (var dbContext = new Context())
            {
                examinations = dbContext.Examinations
                    .Include(p => p.Animal)
                    .Include(p => p.MunicipalContract)
                    .Include(p => p.Organization)
                    .Include(p => p.User).ToList();
                costs = dbContext.Costs
                    .Include(p => p.Locality)
                    .Include(p => p.MunicipalContract).ToList();
            }
            var result = examinations
                        .Join(costs,
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
