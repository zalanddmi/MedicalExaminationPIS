using MedicalExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Data
{
    class ExaminationRepository
    {
        public void AddExamination(Examination examination)
        {
            var maxId = TestData.Examinations.Max(ex => ex.IdExamination);
            examination.IdExamination = maxId + 1;
            TestData.Examinations.Add(examination);
        }
    }
}
