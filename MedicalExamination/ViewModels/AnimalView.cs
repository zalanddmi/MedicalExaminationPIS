using MedicalExamination.Models;
using System.Collections.Generic;

namespace MedicalExamination.ViewModels
{
    public class AnimalView
    {
        public int IdAnimal { get; set; }
        public string RegNumber { get; set; }
        public string Category { get; set; }
        public string SexAnimal { get; set; }
        public int YearBirthday { get; set; }
        public string NumberElectronicChip { get; set; }
        public string Name { get; set; }
        public List<Image> Photos { get; set; }
        public string SignsAnimal { get; set; }
        public string SignsOwner { get; set; }
        public Locality Locality { get; set; }


        public AnimalView()
        {

        }
        public AnimalView(string regNumber, string category, string sexAnimal, int yearBirthday, string numberElectronicChip, string name, List<Image> photos, string signsAnimal, string signsOwner, Locality locality)
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
        public AnimalView(int idAnimal, string regNumber, string category, string sexAnimal, int yearBirthday, string numberElectronicChip, string name, List<Image> photos, string signsAnimal, string signsOwner, Locality locality)
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
    }
}
