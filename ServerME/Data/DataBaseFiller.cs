using ServerME.Models;

namespace ServerME.Data
{
    public class DataBaseFiller
    {
        private Context dbContext;
        public DataBaseFiller()
        {
            dbContext = new Context();
        }
        public void FillDataBase()
        {
            FillTypeOrganization();
            FillMunicipality();   
            FillLocality();
            FillOrganizations();
            FillAnimals();
            FillPrivileges();
            FillUsers();
            FillMunicipalContract();
            FillExamination();
            FillCost();
        }

        private void FillCost()
        {
            var MunicipalContracts = dbContext.MunicipalContracts.ToList();
            var Localities = dbContext.Localities.ToList();
            dbContext.Costs.Add(new Cost(
                1000,
                Localities[0],
                MunicipalContracts[1]));
            dbContext.Costs.Add(new Cost(
                1200,
                Localities[0],
                MunicipalContracts[2]));
            dbContext.Costs.Add(new Cost(
                1100,
                Localities[1],
                MunicipalContracts[2]));

            dbContext.SaveChanges();
        }
        private void FillExamination()
        {
            var Organizations = dbContext.Organizations.ToList();
            var Animals = dbContext.Animals.ToList();
            var Users = dbContext.Users.ToArray();
            var MunicipalContracts = dbContext.MunicipalContracts.ToList();

            dbContext.Examinations.Add(new Examination(
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
            dbContext.Examinations.Add(new Examination(
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
            dbContext.Examinations.Add(new Examination(
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
            dbContext.Examinations.Add(new Examination(
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
            dbContext.Examinations.Add(new Examination(
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
            dbContext.SaveChanges();
        }
        private void FillMunicipalContract()
        {
            var Organizations = dbContext.Organizations.ToList();
            dbContext.MunicipalContracts.Add(new MunicipalContract(
                "123456",
               new DateTime(2010, 3, 20),
               new DateTime(2030, 3, 20),
                new List<string>()
               {
                    @"\dog3.jpg"
               },
                Organizations[6],
                Organizations[3]
                ));

            dbContext.MunicipalContracts.Add(new MunicipalContract(
                "654321",
               new DateTime(2016, 3, 10),
               new DateTime(2031, 8, 20),
                new List<string>()
               {
                    @"\dog3.jpg"
               },
                Organizations[0],
                Organizations[2]
                ));

            dbContext.MunicipalContracts.Add(new MunicipalContract(
               "83746",
              new DateTime(2012, 5, 20),
              new DateTime(2028, 3, 20),
               new List<string>()
              {
                    @"\dog3.jpg"
              },
               Organizations[5],
               Organizations[2]
               ));

            dbContext.MunicipalContracts.Add(new MunicipalContract(
               "83747",
              new DateTime(2012, 5, 20),
              new DateTime(2028, 3, 20),
               new List<string>()
              {
                    @"\dog3.jpg"
              },
               Organizations[8],
               Organizations[2]
               ));
            dbContext.SaveChanges();
        }
        private void FillUsers()
        {
            var Roles = dbContext.Roles.ToList();
            var Organizations = dbContext.Organizations.ToList();   
            dbContext.Users.Add(new User("Пупкин Василий Сергеевич", "Специалист-оператор ОМСУ ГО город Тобольск",
                Roles.First(p => p.Name == "Оператор ОМСУ"), "pupkin", "123", Organizations[6]));
            dbContext.Users.Add(new User("Пупкин Сергей Васильевич", "Куратор ВетСлужбы",
                Roles.First(p => p.Name == "Куратор ВетСлужбы"), "pupkinsv", "123", Organizations[8]));
            dbContext.Users.Add(new User("Иванов Иван Иванович", "Куратор по отлову",
                Roles.First(p => p.Name == "Куратор по отлову"), "iiicur", "123", Organizations[19]));
            dbContext.Users.Add(new User("Сергеев Иван Иванович", "Куратор приюта",
                Roles.First(p => p.Name == "Куратор приюта"), "sibur", "123", Organizations[16]));
            dbContext.Users.Add(new User("Сергеев Иван Петрович", "Оператор ВетСлужбы",
                Roles.First(p => p.Name == "Оператор ВетСлужбы"), "siburIP", "123", Organizations[8]));
            dbContext.Users.Add(new User("Понасенков Иван Петрович", "Оператор по отлову",
                Roles.First(p => p.Name == "Оператор по отлову"), "siburPIP", "123", Organizations[19]));
            dbContext.Users.Add(new User("Кириллов Иван Петрович", "Подписант ВетСлужбы",
                Roles.First(p => p.Name == "Подписант ВетСлужбы"), "kirillIP", "123", Organizations[8]));
            dbContext.Users.Add(new User("Сергеев Сергеевич Петрович", "Подписант по отлову",
                Roles.First(p => p.Name == "Подписант по отлову"), "seriySP", "123", Organizations[19]));
            dbContext.Users.Add(new User("Лауфер Сергеевич Петрович", "Подписант приюта",
                Roles.First(p => p.Name == "Подписант приюта"), "lauferSP", "123", Organizations[16]));
            dbContext.Users.Add(new User("Лауфер Иван Петрович", "Куратор ОМСУ",
                Roles.First(p => p.Name == "Куратор ОМСУ"), "lauferIP", "123", Organizations[5]));
            dbContext.Users.Add(new User("Заленский Андрей Петрович", "Оператор ОМСУ",
                Roles.First(p => p.Name == "Оператор ОМСУ"), "zalan", "123", Organizations[5]));
            dbContext.Users.Add(new User("Петров Андрей Петрович", "Подписант ОМСУ",
                Roles.First(p => p.Name == "Подписант ОМСУ"), "papazoglo", "123", Organizations[5]));
            dbContext.Users.Add(new User("Петров Евгений Петрович", "Оператор приюта",
                Roles.First(p => p.Name == "Оператор приюта"), "pepoz", "123", Organizations[16]));
            dbContext.Users.Add(new User("Андреев Евгений Петрович", "Ветврач",
                Roles.First(p => p.Name == "Ветврач"), "andrep", "123", Organizations[8]));
            dbContext.Users.Add(new User("Андреев Евгений Евгеньевич", "Ветврач приюта",
                Roles.First(p => p.Name == "Ветврач приюта"), "andrepeee", "123", Organizations[16]));

            dbContext.Users.Add(new User("Чернорусов Василий Сергеевич", "Специалист-оператор ОМСУ ГО город Тобольск",
                Roles.First(p => p.Name == "Оператор ОМСУ"), "a", "1", Organizations[6]));
            dbContext.SaveChanges();
        }
        private void FillPrivileges()
        {
            dbContext.Roles.Add(new Role("Куратор ВетСлужбы", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;None"},
                    {"MunicipalContract", "All;None"},
                }));
            dbContext.Roles.Add(new Role("Куратор по отлову", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;None"},
                    {"MunicipalContract", "Org;None"},
                }));
            dbContext.Roles.Add(new Role("Куратор приюта", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;None"},
                    {"MunicipalContract", "Org;None"},
                }));
            dbContext.Roles.Add(new Role("Оператор ВетСлужбы", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;1,2,7"},
                    {"MunicipalContract", "All;None"},
                }));
            dbContext.Roles.Add(new Role("Оператор по отлову", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                }));
            dbContext.Roles.Add(new Role("Подписант ВетСлужбы", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;None"},
                }));
            dbContext.Roles.Add(new Role("Подписант по отлову", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;None"},
                    {"MunicipalContract", "Org;None"},
                }));
            dbContext.Roles.Add(new Role("Подписант приюта", new Dictionary<string, string>
                {
                    {"Animal", "All;None"},
                    {"Organization", "All;None"},
                    {"MunicipalContract", "Org;None"},
                }));
            dbContext.Roles.Add(new Role("Куратор ОМСУ", new Dictionary<string, string>
                {
                    {"Animal", "Mun;None"},
                    {"Organization", "Mun;None"},
                    {"MunicipalContract", "Mun;None"},
                    {"Statistics", "Mun;Mun"}
                }));
            dbContext.Roles.Add(new Role("Оператор ОМСУ", new Dictionary<string, string>
                {
                    {"Animal", "Mun;None"},
                    {"Organization", "Mun;3,4,5,6,8,9,10,11"},
                    {"MunicipalContract", "Mun;Mun"},
                    {"Statistics","Mun;Mun"}
                }));
            dbContext.Roles.Add(new Role("Подписант ОМСУ", new Dictionary<string, string>
                {
                    {"Animal", "Mun;None"},
                    {"Organization", "Mun;None"},
                    {"MunicipalContract", "Mun;None"},
                }));
            dbContext.Roles.Add(new Role("Оператор приюта", new Dictionary<string, string>
                {
                    {"Animal", "All;All"},
                }));
            dbContext.Roles.Add(new Role("Ветврач", new Dictionary<string, string>
                {
                    {"Animal", "All;All"},
                    {"Examination", "All;Org"}
                }));
            dbContext.Roles.Add(new Role("Ветврач приюта", new Dictionary<string, string>
                {
                    {"Animal", "All;All"},
                }));
            dbContext.SaveChanges();
        }

        private void FillAnimals()
        {
            var Localities = dbContext.Localities.ToList(); 
            dbContext.Animals.Add(new Animal("12345678912","Собака", "М",2015,"987654321987","Бобик",new List<string>(){@"\dog1.jpg",}, "Белое пятно", "Красный поводок",Localities[2]));
            dbContext.Animals.Add(new Animal("65738591647", "Кошка","Ж",2019,"876543298127", "Маруся",new List<string>(){@"\cat1.jpg",@"\cat2.jpg",@"\cat3.jpg"},"Трёхцветный окрас","Отсутсвуют",Localities[0]));
            dbContext.Animals.Add(new Animal("87612349571","Собака","Ж",2020,"765826491738","Мухтар",new List<string>(){@"\dog1.jpg",@"\dog2.jpg"},"Травмированные уши","Медальон на шее",Localities[1]));
            dbContext.Animals.Add(new Animal("37489061238","Собака","М",2022,"237589173497","Анфиса",new List<string>(){@"\dog2.jpg"},"Чёрный хвост и чёрное пятно","Ошейник от блох",Localities[4]));
            dbContext.Animals.Add(new Animal("76385901639","Собака","М",2012,"541096894315","Тузик",new List<string>(){@"\dog3.jpg"},"Шрам от ожога на лапе","Отсутсвуют",Localities[3]));
            dbContext.SaveChanges();
        }

        private void FillOrganizations()
        {
            var TypeOrganizations = dbContext.TypeOrganizations.ToList();
            var Localities = dbContext.Localities.ToList(); 
            dbContext.Organizations.Add(new Organization("Приют для животных 'Добрый дом'","1234567890","123","ул. Лесная, д.10",true, TypeOrganizations[2],Localities[0]));
            dbContext.Organizations.Add(new Organization("Организация по отлову животных 'Улов'","5678901234","567","ул. Красноармейская, д.50",true, TypeOrganizations[3],Localities[0]));
            dbContext.Organizations.Add(new Organization("Муниципальная ветеринарная клиника №1","7890123456","789","ул. Садовая, д.15",true,TypeOrganizations[7], Localities[0]));
            dbContext.Organizations.Add(new Organization("Частная ветеринарная клиника 'Ветеринар'", "9012345678", "901", "ул. Красная, д.25", true,TypeOrganizations[8], Localities[1]));
            dbContext.Organizations.Add(new Organization("ИП 'Рыбин А.П.'", "860912143819","860901001","ул. Белышева, 6",false,TypeOrganizations[5], Localities[2]));
            dbContext.Organizations.Add(new Organization("ОМСУ ГО город Тюмень","960912143819","960901001","ул. Беляшева, 66", true, TypeOrganizations[0], Localities[0]));
            dbContext.Organizations.Add(new Organization( "ОМСУ ГО город Тобольск","760934664819","760901001", "ул. Комсомольская, 66",true,TypeOrganizations[0], Localities[1]));
            dbContext.Organizations.Add(new Organization("Организация 8", "1111111111", "111", "ул. Организационная, д.8", true, TypeOrganizations[3], Localities[2]));
            dbContext.Organizations.Add(new Organization("Организация 9", "2222222222", "222", "ул. Организационная, д.9", true, TypeOrganizations[7], Localities[3]));
            dbContext.Organizations.Add(new Organization("Организация 10", "3333333333", "333", "ул. Организационная, д.10", true, TypeOrganizations[8], Localities[4]));
            dbContext.Organizations.Add(new Organization("Организация 11", "4444444444", "444", "ул. Организационная, д.11", false, TypeOrganizations[5], Localities[0]));
            dbContext.Organizations.Add(new Organization("Организация 12", "5555555555", "555", "ул. Организационная, д.12", true, TypeOrganizations[0], Localities[1]));
            dbContext.Organizations.Add(new Organization("Организация 13", "6666666666", "666", "ул. Организационная, д.13", true, TypeOrganizations[1], Localities[2]));
            dbContext.Organizations.Add(new Organization("Организация 14", "7777777777", "777", "ул. Организационная, д.14", true, TypeOrganizations[4], Localities[3]));
            dbContext.Organizations.Add(new Organization("Организация 15", "8888888888", "888", "ул. Организационная, д.15", false, TypeOrganizations[6], Localities[4]));
            dbContext.Organizations.Add(new Organization("Организация 16", "9999999999", "999", "ул. Организационная, д.16", true, TypeOrganizations[9], Localities[0]));
            dbContext.Organizations.Add(new Organization("Организация 17", "1010101010", "101", "ул. Организационная, д.17", true, TypeOrganizations[2], Localities[1]));
            dbContext.Organizations.Add(new Organization("Организация 18", "1212121212", "121", "ул. Организационная, д.18", false, TypeOrganizations[8], Localities[2]));
            dbContext.Organizations.Add(new Organization("Организация 19", "1313131313", "131", "ул. Организационная, д.19", true, TypeOrganizations[7], Localities[3]));
            dbContext.Organizations.Add(new Organization("Организация 20", "1414141414", "141", "ул. Организационная, д.20", true, TypeOrganizations[3], Localities[4]));
            dbContext.SaveChanges();
        }

        private void FillLocality()
        {
            var Municipalities = dbContext.Municipalities.ToList();
            dbContext.Localities.Add(new Locality("г. Тюмень",       Municipalities[0]));
            dbContext.Localities.Add(new Locality("г. Тобольск",     Municipalities[1]));
            dbContext.Localities.Add(new Locality("р.п. Сумкино",    Municipalities[1]));
            dbContext.Localities.Add(new Locality("г. Ишим",         Municipalities[2]));
            dbContext.Localities.Add(new Locality("г. Нижняя Тавда", Municipalities[3]));
            dbContext.SaveChanges();
        }

        private void FillMunicipality()
        {
            dbContext.Municipalities.Add(new Municipality("Городской округ город Тюмень"));
            dbContext.Municipalities.Add(new Municipality("Городской округ город Тобольск"));
            dbContext.Municipalities.Add(new Municipality("Городской округ город Ишим"));
            dbContext.Municipalities.Add(new Municipality("Нижнетавдинский муниципальный район"));
            dbContext.SaveChanges();
        }

        private void FillTypeOrganization()
        {
            dbContext.TypeOrganizations.Add(new TypeOrganization("Исполнительный орган государственной власти"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Орган местного самоуправления"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Приют"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Организация по отлову"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Организация по отлову и приют"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Организация по транспортировке"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Ветеринарная клиника: государственная"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Ветеринарная клиника: муниципальная"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Ветеринарная клиника: частная"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Благотворительный фонд"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Организации по продаже товаров и предоставлению услуг для животных"));
            dbContext.TypeOrganizations.Add(new TypeOrganization("Заявитель"));
            dbContext.SaveChanges();
        }
    }
}
