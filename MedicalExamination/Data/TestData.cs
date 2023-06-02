using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public static class TestData
    {
        public static List<Municipality> Municipalities = new List<Municipality>();
        public static List<Locality> Localities = new List<Locality>();
        public static List<TypeOrganization> TypeOrganizations = new List<TypeOrganization>();
        public static List<Organization> Organizations = new List<Organization>();
        public static List<Animal> Animals = new List<Animal>();
        public static List<Privilege> Privileges = new List<Privilege>();
        public static List<User> Users = new List<User>();
        public static List<MunicipalContract> MunicipalContracts = new List<MunicipalContract>();
        public static List<Examination> Examinations = new List<Examination>();
        public static List<Cost> Costs = new List<Cost>();

        static TestData()
        {
            FillMunicipalities();
            FillLocalities();
            FillTypeOrganizations();
            FillOrganizations();
            FillAnimals();
            FillPrivileges();
            FillUsers();
            FillMunicipalContract();
            FillExamination();
            FillCost();
        }

        private static void FillMunicipalities()
        {
            Municipalities.Add(new Municipality(1, "Городской округ город Тюмень"));
            Municipalities.Add(new Municipality(2, "Городской округ город Тобольск"));
            Municipalities.Add(new Municipality(3, "Городской округ город Ишим"));
            Municipalities.Add(new Municipality(4, "Нижнетавдинский муниципальный район"));
        }

        private static void FillLocalities()
        {
            Localities.Add(new Locality(1, "г. Тюмень", Municipalities[0]));
            Localities.Add(new Locality(2, "г. Тобольск", Municipalities[1]));
            Localities.Add(new Locality(3, "р.п. Сумкино", Municipalities[1]));
            Localities.Add(new Locality(4, "г. Ишим", Municipalities[2]));
            Localities.Add(new Locality(5, "г. Нижняя Тавда", Municipalities[3]));
        }

        private static void FillTypeOrganizations()
        {
            TypeOrganizations.Add(new TypeOrganization(1, "Исполнительный орган государственной власти"));
            TypeOrganizations.Add(new TypeOrganization(2, "Орган местного самоуправления"));
            TypeOrganizations.Add(new TypeOrganization(3, "Приют"));
            TypeOrganizations.Add(new TypeOrganization(4, "Организация по отлову"));
            TypeOrganizations.Add(new TypeOrganization(5, "Организация по отлову и приют"));
            TypeOrganizations.Add(new TypeOrganization(6, "Организация по транспортировке"));
            TypeOrganizations.Add(new TypeOrganization(7, "Ветеринарная клиника: государственная"));
            TypeOrganizations.Add(new TypeOrganization(8, "Ветеринарная клиника: муниципальная"));
            TypeOrganizations.Add(new TypeOrganization(9, "Ветеринарная клиника: частная"));
            TypeOrganizations.Add(new TypeOrganization(10, "Благотворительный фонд"));
            TypeOrganizations.Add(new TypeOrganization(11, "Организации по продаже товаров и предоставлению услуг для животных"));
            TypeOrganizations.Add(new TypeOrganization(12, "Заявитель"));
        }

        private static void FillOrganizations()
        {
            Organizations.Add(new Organization(
                "Приют для животных 'Добрый дом'",
                "1234567890",
                "123",
                "ул. Лесная, д.10",
                true,
                TypeOrganizations[2],
                Localities[0]));
            Organizations[0].IdOrganization = 1;
            Organizations.Add(new Organization(
                "Организация по отлову животных 'Улов'",
                "5678901234",
                "567",
                "ул. Красноармейская, д.50",
                true,
                TypeOrganizations[3],
                Localities[0]));
            Organizations[1].IdOrganization = 2;
            Organizations.Add(new Organization(
                "Муниципальная ветеринарная клиника №1",
                "7890123456",
                "789",
                "ул. Садовая, д.15",
                true,
                TypeOrganizations[7],
                Localities[0]));
            Organizations[2].IdOrganization = 3;
            Organizations.Add(new Organization(
                "Частная ветеринарная клиника 'Ветеринар'",
                "9012345678",
                "901",
                "ул. Красная, д.25",
                true,
                TypeOrganizations[8],
                Localities[1]));
            Organizations[3].IdOrganization = 4;
            Organizations.Add(new Organization(
                "ИП 'Рыбин А.П.'",
                "860912143819",
                "860901001",
                "ул. Белышева, 6",
                false,
                TypeOrganizations[5],
                Localities[2]));
            Organizations[4].IdOrganization = 5;
            Organizations.Add(new Organization(
                "ОМСУ ГО город Тюмень",
                "960912143819",
                "960901001",
                "ул. Беляшева, 66",
                true,
                TypeOrganizations[0],
                Localities[0]));
            Organizations[5].IdOrganization = 6;
            Organizations.Add(new Organization(
                "ОМСУ ГО город Тобольск",
                "760934664819",
                "760901001",
                "ул. Комсомольская, 66",
                true,
                TypeOrganizations[0],
                Localities[1]));
            Organizations[6].IdOrganization = 7;
        }
        private static void FillAnimals()
        {
            Animals.Add(new Animal(
               "12345678912",
               "Собака",
               "М",
               2015,
               "987654321987",
               "Бобик",
               new List<string>()
               {
        "D:\\Фото\\Dog1(1).jpg",
               },
            "Белое пятно",
               "Красный поводок",
               Localities[2]));
            Animals[0].IdAnimal = 1;
            Animals.Add(new Animal(
               "65738591647",
               "Кошка",
               "Ж",
               2019,
               "876543298127",
               "Маруся",
               new List<string>()
               {
        "D:\\Фото\\Cat2(1).jpg",
        "D:\\Фото\\Cat2(2).jpg",
        "D:\\Фото\\Cat2(3).jpg"
               },
               "Трёхцветный окрас",
               "Отсутсвуют",
               Localities[0]));
            Animals[1].IdAnimal = 2;
            Animals.Add(new Animal(
               "87612349571",
               "Собака",
               "Ж",
               2020,
               "765826491738",
               "Мухтар",
               new List<string>()
               {
        "D:\\Фото\\Dog3(1).jpg",
        "D:\\Фото\\Dog3(2).jpg"
               },
               "Травмированные уши",
               "Медальон на шее",
               Localities[1]));
            Animals[2].IdAnimal = 3;
            Animals.Add(new Animal(
               "37489061238",
               "Собака",
               "М",
               2022,
               "237589173497",
               "Анфиса",
               new List<string>()
               {
        "D:\\Фото\\Dog4(1).jpg"
               },
               "Чёрный хвост и чёрное пятно",
               "Ошейник от блох",
               Localities[4]));
            Animals[3].IdAnimal = 4;
            Animals.Add(new Animal(
               "76385901639",
               "Собака",
               "М",
               2012,
               "541096894315",
               "Тузик",
               new List<string>()
               {
        "D:\\Фото\\Dog5(1).jpg"
               },
               "Шрам от ожога на лапе",
               "Отсутсвуют",
               Localities[3]));
            Animals[4].IdAnimal = 5;
        }
        private static void FillMunicipalContract()
        {
            MunicipalContracts.Add(new MunicipalContract(
                "123456",
               new DateTime(2010, 3, 20),
               new DateTime(2030, 3, 20),
                new List<string>()
               {
        "D:\\Фото\\Dog5(1).jpg"
               },
                Organizations[6],
                Organizations[3]
                ));
            MunicipalContracts[0].IdMunicipalContract = 1;
            MunicipalContracts.Add(new MunicipalContract(
                "654321",
               new DateTime(2016, 3, 10),
               new DateTime(2031, 8, 20),
                new List<string>()
               {
        "D:\\Фото\\Dog5(1).jpg"
               },
                Organizations[0],
                Organizations[2]
                ));
            MunicipalContracts[1].IdMunicipalContract = 2;
            MunicipalContracts.Add(new MunicipalContract(
               "83746",
              new DateTime(2012, 5, 20),
              new DateTime(2028, 3, 20),
               new List<string>()
              {
        "D:\\Фото\\Dog5(1).jpg"
              },
               Organizations[5],
               Organizations[2]
               ));
            MunicipalContracts[2].IdMunicipalContract = 3;

        }
        private static void FillCost()
        {
            Costs.Add(new Cost(
                1000,
                Localities[0],
                MunicipalContracts[1]));
            Costs[0].IdCost = 1;
            Costs.Add(new Cost(
                1200,
                Localities[0],
                MunicipalContracts[2]));
            Costs[1].IdCost = 2;
            Costs.Add(new Cost(
                1100,
                Localities[1],
                MunicipalContracts[2]));
            Costs[2].IdCost = 3;
        }
        private static void FillExamination()
        {
            Examinations.Add(new Examination(
                "Агрессивность",
                "Удовлетворительное",
                "38",
                "Без повреждений",
                "Гладкая",
                "Без ранений",
                false,
                "Здоров",
                "Диагностические манипуляции",
                "Витамины",
                new DateTime(2023, 3, 20),
                Organizations[2],
                Animals[0],
                Users[0],
                MunicipalContracts[1]));
            Examinations[0].IdExamination = 1;
            Examinations.Add(new Examination(
                "Пугливость",
                "Тяжелое",
                "39",
                "Без повреждений",
                "Запутанная",
                "Травма правой передней лапы ",
                true,
                "Перелом",
                "Диагностические манипуляции",
                "Обезболивающее",
                new DateTime(2023, 3, 25),
                Organizations[5],
                Animals[1],
                Users[0],
                MunicipalContracts[2]));
            Examinations[1].IdExamination = 2;
            Examinations.Add(new Examination(
                "Агрессивность",
                "Удовлетворительное",
                "38",
                "Без повреждений",
                "Гладкая",
                "Без ранений",
                false,
                "Здоров",
                "Диагностические манипуляции",
                "Витамины",
                new DateTime(2023, 2, 15),
                Organizations[6],
                Animals[2],
                Users[0],
                MunicipalContracts[1]));
            Examinations[2].IdExamination = 3;
            Examinations.Add(new Examination(
                "Спокойное поведение",
                "Удовлетворительное",
                "38",
                "С высыпаниями",
                "Гладкая",
                "Без ранений",
                true,
                "Бешенство",
                "Анализы",
                "Уколы",
                new DateTime(2023, 3, 20),
                Organizations[2],
                Animals[3],
                Users[0],
                MunicipalContracts[0]));
            Examinations[3].IdExamination = 4;
            Examinations.Add(new Examination(
                "Агрессивность",
                "Тяжелое",
                "40",
                "Присутствуют шрамы",
                "Спутанная",
                "Без ранений",
                true,
                "Бешенство",
                "Анализы",
                "Уколы",
                new DateTime(2023, 4, 11),
                Organizations[5],
                Animals[4],
                Users[0],
                MunicipalContracts[0]));
            Examinations[4].IdExamination = 5;
        }

        private static void FillPrivileges()
        {
            Privileges.Add(new Privilege("Куратор ВетСлужбы", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;None"},
                {"MunicipalContract", "All;None"},
            }));
            Privileges.Add(new Privilege("Куратор по отлову", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;None"},
                {"MunicipalContract", "Org;None"},
            }));
            Privileges.Add(new Privilege("Куратор приюта", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;None"},
                {"MunicipalContract", "Org;None"},
            }));
            Privileges.Add(new Privilege("Оператор ВетСлужбы", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;1,2,7"},
                {"MunicipalContract", "All;None"},
            }));
            Privileges.Add(new Privilege("Оператор по отлову", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
            }));
            Privileges.Add(new Privilege("Подписант ВетСлужбы", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;None"},
            }));
            Privileges.Add(new Privilege("Подписант по отлову", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;None"},
                {"MunicipalContract", "Org;None"},
            }));
            Privileges.Add(new Privilege("Подписант приюта", new Dictionary<string, string>
            {
                {"Animal", "All;None"},
                {"Organization", "All;None"},
                {"MunicipalContract", "Org;None"},
            }));
            Privileges.Add(new Privilege("Куратор ОМСУ", new Dictionary<string, string>
            {
                {"Animal", "Mun;None"},
                {"Organization", "Mun;None"},
                {"MunicipalContract", "Mun;None"},
                {"Statistics", "Mun;Mun"}
            }));
            Privileges.Add(new Privilege("Оператор ОМСУ", new Dictionary<string, string>
            {
                {"Animal", "Mun;None"},
                {"Organization", "Mun;3,4,5,6,8,9,10,11"},
                {"MunicipalContract", "Mun;Mun"},
                {"Statistics","Mun;Mun"}
            }));
            Privileges.Add(new Privilege("Подписант ОМСУ", new Dictionary<string, string>
            {
                {"Animal", "Mun;None"},
                {"Organization", "Mun;None"},
                {"MunicipalContract", "Mun;None"},
            }));
            Privileges.Add(new Privilege("Оператор приюта", new Dictionary<string, string>
            {
                {"Animal", "All;All"},
            }));
            Privileges.Add(new Privilege("Ветврач", new Dictionary<string, string>
            {
                {"Animal", "All;All"},
                {"Examination", "All; All"}
            }));
            Privileges.Add(new Privilege("Ветврач приюта", new Dictionary<string, string>
            {
                {"Animal", "All;All"},
            }));
        }
        private static void FillUsers()
        {
            Users.Add(new User(1, "Пупкин Василий Сергеевич", "Специалист-подписант ОМСУ",
                "Оператор ОМСУ", "pupkin", "123", Organizations[5]));
        }
    }
}
