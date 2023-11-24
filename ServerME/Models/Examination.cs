using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerME.Models
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
        
        public Examination()
        {

        }
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

        public override string ToString()
        {
            var result = $"PeculiaritiesBehavior - {PeculiaritiesBehavior}\nConditionAnimal - {ConditionAnimal}\nTemperature - {Temperature}" +
                $"\nSkin - {Skin}\nWool - {Wool}\nDamage - {Damage}\nEmergencyAssistance - {EmergencyAssistance}\nDiagnosis - {Diagnosis}" +
                $"\nManipulations - {Manipulations}\nTreatment - {Treatment}\nDateExamination - {DateExamination}\nIdOrganization - {Organization.IdOrganization}" +
                $"\nIdAnimal - {Animal.IdAnimal}\nIdUser - {User.IdUser}\nIdMunicipalContract - {MunicipalContract.IdMunicipalContract}";
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj is Examination objExamination)
            {
                return IdExamination.Equals(objExamination.IdExamination) && PeculiaritiesBehavior.Equals(objExamination.PeculiaritiesBehavior)
                    && ConditionAnimal.Equals(objExamination.ConditionAnimal) && Temperature.Equals(objExamination.Temperature)
                    && Skin.Equals(objExamination.Skin) && Wool.Equals(objExamination.Wool)
                    && Damage.Equals(objExamination.Damage) && EmergencyAssistance.Equals(objExamination.EmergencyAssistance)
                    && Diagnosis.Equals(objExamination.Diagnosis) && Manipulations.Equals(objExamination.Manipulations)
                    && Treatment.Equals(objExamination.Treatment) && DateExamination.Equals(objExamination.DateExamination)
                    && Organization.IdOrganization.Equals(objExamination.Organization.IdOrganization) && Animal.IdAnimal.Equals(objExamination.Animal.IdAnimal)
                    && User.IdUser.Equals(objExamination.User.IdUser) && MunicipalContract.IdMunicipalContract.Equals(objExamination.MunicipalContract.IdMunicipalContract);
            }
            return false;
        }
    }
}
