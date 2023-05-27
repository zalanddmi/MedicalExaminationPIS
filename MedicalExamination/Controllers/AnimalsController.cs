using MedicalExamination.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Controllers
{
    public class AnimalsController
    {
        public List<string[]> ShowAnimals()
        {
            return new AnimalsService().GetAnimals();
        }
    }
}
