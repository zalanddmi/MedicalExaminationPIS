using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalExamination.Models
{
    public class Inspection
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
        public DateTime DateInspection;
        public Organization Organization;
        public Animal Animal;
        public User User;

        public Inspection ( string peculiaritiesBehavior, string conditionAnimal, string temperature, string skin, string wool, 
            string damage, string emergencyAssistance, string diagnosis, string manipulations, string treatment, 
            DateTime dateInspection, Organization organization, Animal animal, User user)
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
            DateInspection = dateInspection;
            Organization = organization;
            Animal = animal;
            User = user;
        }

    }
    public class User
    {
        public string Name;
        public string Post;

        public User (string name, string post)
        {
            Name = name;
            Post = post;
        }
    }
   
   
}
