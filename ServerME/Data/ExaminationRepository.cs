using Microsoft.EntityFrameworkCore;
using ServerME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Utils;

namespace ServerME.Data
{
    public class ExaminationRepository
    {
        private Utils.Logger<Examination> logger;
        public ExaminationRepository()
        {
            logger = new Utils.Logger<Examination>();
        }
        public void AddExamination(User user, Examination examination)
        {
            using (var dbContext = new Context())
	        {
                examination.Animal = dbContext.Animals.First(p => p.IdAnimal == examination.Animal.IdAnimal);
                examination.Organization = dbContext.Organizations.First(p => p.IdOrganization == examination.Organization.IdOrganization);
                examination.MunicipalContract = dbContext.MunicipalContracts.First(p => p.IdMunicipalContract == examination.MunicipalContract.IdMunicipalContract);
                examination.User = dbContext.Users.First(p => p.IdUser == examination.User.IdUser);
                dbContext.Examinations.Add(examination);
                dbContext.SaveChanges();
                logger.LogAdding(user, examination);
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
                    .Include(p => p.Animal.Locality)
                    .Include(p => p.Animal.Locality.Municipality)
                    .Include(p => p.MunicipalContract)
                    .Include(p => p.MunicipalContract.Executor.Locality)
                    .Include(p => p.MunicipalContract.Customer.Locality)
                    .Include(p => p.Organization)
                    .Include(p => p.User).ToList();
                costs = dbContext.Costs
                    .Include(p => p.Locality)
                    .Include(p => p.Locality.Municipality)
                    .Include(p => p.MunicipalContract).ToList();
            }
            var result = examinations
                        .Join(costs,
                              e => e.MunicipalContract.IdMunicipalContract,
                              c => c.MunicipalContract.IdMunicipalContract,
                              (e, c) => new { Examination = e, Cost = c })
                        .Where(ec => ec.Examination.DateExamination.Date >= from.Date
                                     && ec.Examination.DateExamination.Date <= to.Date
                                     && ec.Cost.Locality.IdLocality == locality.IdLocality
                                     && ec.Examination.Organization.Locality.IdLocality == locality.IdLocality)
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
