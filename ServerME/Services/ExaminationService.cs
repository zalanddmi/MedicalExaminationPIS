using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Data;
using ServerME.Models;
using ServerME.ViewModels;

namespace ServerME.Services
{
    class ExaminationService
    {
        private PrivilegeService privilegeService;
        private AnimalsRepository animalsRepository;
        private ExaminationRepository examinationRepository;
        public ExaminationService()
        {
            privilegeService = new PrivilegeService();
            animalsRepository = new AnimalsRepository();    
            examinationRepository = new ExaminationRepository();
        }
        public void MakeExamination(ExaminationView data, User user)
        {
            var resultCheck = privilegeService.CheckUserForExamination(user);
            if (resultCheck)
            {

                var animal = animalsRepository.GetAnimal(Convert.ToInt32(data.animalId));

                var examination = new Examination(data.PeculiaritiesBehavior, data.ConditionAnimal, 
                    data.Temperature, data.Skin, data.Wool, data.Damage, data.EmergencyAssistance, data.Diagnosis, 
                    data.Manipulations, data.Treatment, data.DateExamination, user.Organization, animal, user, data.MunicipalContract);

                examinationRepository.AddExamination(user, examination);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
        public string[] MapExamination(Examination examination)
        {
            var examinationList = new List<string>
            {
                    examination.PeculiaritiesBehavior,
                    examination.ConditionAnimal,
                    examination.Temperature,
                    examination.Wool,
                    examination.Damage,
                    examination.EmergencyAssistance ? "Да" : "Нет",
                    examination.Diagnosis,
                    examination.Manipulations,
                    examination.Treatment,
                    examination.DateExamination.ToShortDateString(),
                    examination.Organization.Name,
                    examination.Animal.Name,
                    examination.User.Name,
                    examination.User.Post,
                    examination.MunicipalContract.Number,
      
            };
            return examinationList.ToArray();
        }
    }
}
