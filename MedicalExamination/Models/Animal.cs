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
        public string RegNumber;
        public string Category;
        public string SexAnimal;
        public int YearBirthday;
        public string NumberElectronicChip;
        public string Name;
        public List<Image> Images;
        public string SignsAnimal;
        public string SignsOwner;
        public Locality Locality;

        public Animal (string regNumber, string category, string sexAnimal, int yearBirthday, string numberElectronicChip, 
            string name, List<Image> images, string signsAnimal, string signsOwner, Locality locality)
        {
            RegNumber = regNumber;
            Category = category;
            SexAnimal = sexAnimal;
            YearBirthday = yearBirthday;
            NumberElectronicChip = numberElectronicChip;
            Name = name;
            Images = images;
            SignsAnimal = signsAnimal;
            SignsOwner = signsOwner;
            Locality = locality;
        }
    }
}
