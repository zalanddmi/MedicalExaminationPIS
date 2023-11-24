using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ServerME.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string RegNumber { get; set; }
        public string Category { get; set; }
        public string SexAnimal { get; set; }
        public int YearBirthday { get; set; }
        public string NumberElectronicChip { get; set; }
        public string Name { get; set; }
        public List<string> Photos { get; set; }
        public string SignsAnimal { get; set; }
        public string SignsOwner { get; set; }
        public Locality Locality { get; set; }

        [JsonIgnore] 
        public List<Examination> Examinations { get; set; } = new();
        public Animal()
        {

        }
        public Animal(string regNumber, string category, string sexAnimal, int yearBirthday, string numberElectronicChip,
            string name, List<string> photos, string signsAnimal, string signsOwner, Locality locality)
        {
            RegNumber = regNumber;
            Category = category;
            SexAnimal = sexAnimal;
            YearBirthday = yearBirthday;
            NumberElectronicChip = numberElectronicChip;
            Name = name;
            Photos = photos;
            SignsAnimal = signsAnimal;
            SignsOwner = signsOwner;
            Locality = locality;
        }

        public Animal(int idAnimal, string regNumber, string category, string sexAnimal, int yearBirthday, string numberElectronicChip, string name, List<string> photos, string signsAnimal, string signsOwner, Locality locality)
        {
            IdAnimal = idAnimal;
            RegNumber = regNumber;
            Category = category;
            SexAnimal = sexAnimal;
            YearBirthday = yearBirthday;
            NumberElectronicChip = numberElectronicChip;
            Name = name;
            Photos = photos;
            SignsAnimal = signsAnimal;
            SignsOwner = signsOwner;
            Locality = locality;
        }
        public override string ToString()
        {
            var result = $"RegNumber - {RegNumber}\nCategory - {Category}\nSexAnimal - {SexAnimal}\nYearBirthday - {YearBirthday}" +
                $"\nNumberElectronicChip - {NumberElectronicChip}\nName - {Name}\nSignsAnimal - {SignsAnimal}\nSignsOwner - {SignsOwner}" +
                $"\nIdLocality - {Locality.IdLocality}";
            return result; 
        }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj is Animal objAnimal)
            {
                return IdAnimal.Equals(objAnimal.IdAnimal) && RegNumber.Equals(objAnimal.RegNumber)
                    && Category.Equals(objAnimal.Category) && SexAnimal.Equals(objAnimal.SexAnimal)
                    && YearBirthday.Equals(objAnimal.YearBirthday) && NumberElectronicChip.Equals(objAnimal.NumberElectronicChip)
                    && Name.Equals(objAnimal.Name) && SignsAnimal.Equals(objAnimal.SignsAnimal)
                    && SignsOwner.Equals(objAnimal.SignsOwner) && Locality.IdLocality.Equals(objAnimal.Locality.IdLocality);
            } 
            return false;
        }
    }
}
