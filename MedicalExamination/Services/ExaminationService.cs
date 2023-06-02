﻿using MedicalExamination.Data;
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
                var organization = TestData.Organizations[int.Parse(examinationData[11]) - 1];
                var animal = TestData.Animals[int.Parse(examinationData[12]) - 1];
                var user = TestData.Users[int.Parse(examinationData[13]) - 1];
                var municipalcontract= TestData.MunicipalContracts[int.Parse(examinationData[14]) - 1];
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
    }
}
