using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Examination
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
        public Organization Organization { get; set; }
        public Animal Animal { get; set; }
        public User User { get; set; }
        public MunicipalContract MunicipalContract { get; set; }

        public Examination (string peculiaritiesBehavior, string conditionAnimal, string temperature, string skin, string wool, 
            string damage, bool emergencyAssistance, string diagnosis, string manipulations, string treatment, 
            DateTime dateExamination, Organization organization, Animal animal, User user, MunicipalContract municipalContract)
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
            Organization = organization;
            Animal = animal;
            User = user;
            MunicipalContract = municipalContract;
        }

    }
}
