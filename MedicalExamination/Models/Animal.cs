using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedicalExamination.Models
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
        //public List<Image> Images { get; set; }
        public string SignsAnimal { get; set; }
        public string SignsOwner { get; set; }
        public Locality Locality { get; set; }

        public Animal(string regNumber, string category, string sexAnimal, int yearBirthday, string numberElectronicChip,
            string name, string signsAnimal, string signsOwner, Locality locality)
        {
            RegNumber = regNumber;
            Category = category;
            SexAnimal = sexAnimal;
            YearBirthday = yearBirthday;
            NumberElectronicChip = numberElectronicChip;
            Name = name;
            //Images = images;
            SignsAnimal = signsAnimal;
            SignsOwner = signsOwner;
            Locality = locality;
        }
    }
}
