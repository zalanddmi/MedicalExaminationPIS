using MedicalExamination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.ViewModels
{
    public class ExaminationView
    {
        public int IdExamination { get; set; }
        public string PeculiaritiesBehavior { get; set; }
        public string ConditionAnimal { get; set; }
        public string Temperature { get; set; }
        public string Skin { get; set; }
        public string Wool { get; set; }
        public string Damage { get; set; }
        public bool EmergencyAssistance { get; set; }
        public string Diagnosis { get; set; }
        public string Manipulations { get; set; }
        public string Treatment { get; set; }
        public DateTime DateExamination { get; set; }
        public int animalId { get; set; }
        public MunicipalContract MunicipalContract { get; set; }

        public ExaminationView()
        {

        }
        public ExaminationView(string peculiaritiesBehavior, string conditionAnimal, string temperature, string skin, string wool, string damage, bool emergencyAssistance, string diagnosis, string manipulations, string treatment, DateTime dateExamination, int animalId, MunicipalContract municipalContract)
        {
            PeculiaritiesBehavior = peculiaritiesBehavior;
            ConditionAnimal = conditionAnimal;
            Temperature = temperature;
            Skin = skin;
            Wool = wool;
            Damage = damage;
            EmergencyAssistance = emergencyAssistance;
            Diagnosis = diagnosis;
            Manipulations = manipulations;
            Treatment = treatment;
            DateExamination = dateExamination;
            this.animalId = animalId;
            MunicipalContract = municipalContract;
        }
        public ExaminationView(int idExamination, string peculiaritiesBehavior, string conditionAnimal, string temperature, string skin, string wool, string damage, bool emergencyAssistance, string diagnosis, string manipulations, string treatment, DateTime dateExamination, int animalId, MunicipalContract municipalContract)
        {
            IdExamination = idExamination;
            PeculiaritiesBehavior = peculiaritiesBehavior;
            ConditionAnimal = conditionAnimal;
            Temperature = temperature;
            Skin = skin;
            Wool = wool;
            Damage = damage;
            EmergencyAssistance = emergencyAssistance;
            Diagnosis = diagnosis;
            Manipulations = manipulations;
            Treatment = treatment;
            DateExamination = dateExamination;
            this.animalId = animalId;
            MunicipalContract = municipalContract;
        }
    }
}
