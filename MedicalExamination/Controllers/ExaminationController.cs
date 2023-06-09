using MedicalExamination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Controllers
{
    class ExaminationController
    {
        public void AddExamination(string[] examinationData)
        {
            new ExaminationService().MakeExamination(examinationData);
        }
        public string[] ShowExaminationCardToView(string choosedExamination)
        {
            return new ExaminationService().GetExaminationCardToView(choosedExamination);
        }
    }
}
