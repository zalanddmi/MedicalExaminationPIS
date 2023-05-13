using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Examination
    {
        public string PeculiaritiesBehavior;
        public string ConditionAnimal;
        public string Temperature;
        public string Skin;
        public string Wool;
        public string Damage;
        public string EmergencyAssistance;
        public string Diagnosis;
        public string Manipulations;
        public string Treatment;
        public DateTime DateExamination;
        public Organization Organization;
        public Animal Animal;
        public User User;

        public Examination (string peculiaritiesBehavior, string conditionAnimal, string temperature, string skin, string wool, 
            string damage, string emergencyAssistance, string diagnosis, string manipulations, string treatment, 
            DateTime dateExamination, Organization organization, Animal animal, User user)
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
        }

    }
}
