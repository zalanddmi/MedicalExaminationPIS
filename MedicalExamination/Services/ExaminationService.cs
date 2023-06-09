using MedicalExamination.Data;
using MedicalExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalExamination.Services
{
    class ExaminationService
    {
        public void MakeExamination(string[] examinationData)
        {
            var resultCheck = new PrivilegeService().CheckUserForExamination();
            if (resultCheck)
            {
                var organization = new OrganizationsRepository().GetOrganization(examinationData[11]);
                var animal = new AnimalsRepository().GetAnimal(examinationData[12]);
                var idUser = int.Parse(examinationData[13]);
                var user = TestData.Users.First(u => u.IdUser == idUser);
                var municipalcontract = new MunicipalContractsRepository().GetMunicipalContract(examinationData[14]);
                var examination = new Examination(examinationData[0], examinationData[1], examinationData[2], examinationData[3],
                   examinationData[4], examinationData[5], examinationData[6]=="Да", examinationData[7], examinationData[8], examinationData[9], Convert.ToDateTime(examinationData[10]),
                   organization,animal, user, municipalcontract);
                new ExaminationRepository().AddExamination(examination);
            }
            else
            {
                MessageBox.Show("");
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
