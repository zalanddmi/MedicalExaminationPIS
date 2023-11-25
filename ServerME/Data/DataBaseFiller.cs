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
        public DataBaseFiller(bool needCreate)
        {
            dbContext = new Context(null);
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
                1100,
                Localities[1],
                MunicipalContracts[2]));
            dbContext.Costs.Add(new Cost(
                1200,
                Localities[2],
                MunicipalContracts[2]));
            dbContext.Costs.Add(new Cost(
                1300,
                Localities[0],
                MunicipalContracts[3]));
            dbContext.Costs.Add(new Cost(
                1000,
                Localities[1],
                MunicipalContracts[4]));
            dbContext.Costs.Add(new Cost(
                1500,
                Localities[0],
                MunicipalContracts[5]));
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
                Organizations[4],
                Animals[0],
                Users[0],
                MunicipalContracts[2]));
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
                MunicipalContracts[1]));
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
                Organizations[3],
                Animals[2],
                Users[0],
                MunicipalContracts[2]));
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
            dbContext.Examinations.Add(new Examination(
                "Агрессивность",
                "Удовлетворительное",
                "38",
                "Без повреждений",
                "Гладкая",
                "Без ранений",
                false,
                "Перелом",
                "Диагностические манипуляции",
                "Витамины",
                new DateTime(2023, 5, 20),
                Organizations[4],
                Animals[0],
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
                "Перелом",
                "Диагностические манипуляции",
                "Витамины",
                new DateTime(2023, 6, 20),
                Organizations[4],
                Animals[0],
                Users[0],
                MunicipalContracts[2]));
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
               "54320",
              new DateTime(2015, 4, 20),
              new DateTime(2025, 2, 20),
               new List<string>()
              {
                    @"\dog5.jpg"
              },
               Organizations[8],
               Organizations[2]
               ));

            dbContext.MunicipalContracts.Add(new MunicipalContract(
               "56948",
              new DateTime(2020, 6, 15),
              new DateTime(2030, 1, 15),
               new List<string>()
              {
                    @"\cat3.jpg"
              },
               Organizations[7],
               Organizations[12]
               ));

            dbContext.MunicipalContracts.Add(new MunicipalContract(
               "63485",
              new DateTime(2005, 12, 20),
              new DateTime(2025, 10, 15),
               new List<string>()
              {
                    @"\cat5.jpg"
              },
               Organizations[5],
               Organizations[15]
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
                Roles.First(p => p.Name == "Куратор ВетСлужбы"), "pupkinsv", "123", Organizations[16]));
            dbContext.Users.Add(new User("Иванов Иван Иванович", "Куратор по отлову",
                Roles.First(p => p.Name == "Куратор по отлову"), "iiicur", "123", Organizations[19]));
            dbContext.Users.Add(new User("Сергеев Иван Иванович", "Куратор приюта",
                Roles.First(p => p.Name == "Куратор приюта"), "sibur", "123", Organizations[8]));
            dbContext.Users.Add(new User("Сергеев Иван Петрович", "Оператор ВетСлужбы",
                Roles.First(p => p.Name == "Оператор ВетСлужбы"), "siburIP", "123", Organizations[17]));
            dbContext.Users.Add(new User("Понасенков Иван Петрович", "Оператор по отлову",
                Roles.First(p => p.Name == "Оператор по отлову"), "siburPIP", "123", Organizations[19]));
            dbContext.Users.Add(new User("Кириллов Иван Петрович", "Подписант ВетСлужбы",
                Roles.First(p => p.Name == "Подписант ВетСлужбы"), "kirillIP", "123", Organizations[21]));
            dbContext.Users.Add(new User("Сергеев Сергеевич Петрович", "Подписант по отлову",
                Roles.First(p => p.Name == "Подписант по отлову"), "seriySP", "123", Organizations[19]));
            dbContext.Users.Add(new User("Лауфер Сергеевич Петрович", "Подписант приюта",
                Roles.First(p => p.Name == "Подписант приюта"), "lauferSP", "123", Organizations[16]));
            dbContext.Users.Add(new User("Лауфер Иван Петрович", "Куратор ОМСУ",
                Roles.First(p => p.Name == "Куратор ОМСУ"), "lauferIP", "123", Organizations[20]));
            dbContext.Users.Add(new User("Заленский Андрей Петрович", "Оператор ОМСУ",
                Roles.First(p => p.Name == "Оператор ОМСУ"), "zalan", "123", Organizations[22]));
            dbContext.Users.Add(new User("Петров Андрей Петрович", "Подписант ОМСУ",
                Roles.First(p => p.Name == "Подписант ОМСУ"), "papazoglo", "123", Organizations[5]));
            dbContext.Users.Add(new User("Петров Евгений Петрович", "Оператор приюта",
                Roles.First(p => p.Name == "Оператор приюта"), "pepoz", "123", Organizations[9]));
            dbContext.Users.Add(new User("Андреев Евгений Петрович", "Ветврач",
                Roles.First(p => p.Name == "Ветврач"), "andrep", "123", Organizations[18]));
            dbContext.Users.Add(new User("Андреев Евгений Евгеньевич", "Ветврач приюта",
                Roles.First(p => p.Name == "Ветврач приюта"), "andrepeee", "123", Organizations[10]));
            
            dbContext.Users.Add(new User("Чернорусов Василий Сергеевич", "Специалист-оператор ОМСУ ГО город Тобольск",
                Roles.First(p => p.Name == "Оператор ОМСУ"), "a", "1", Organizations[6]));

            dbContext.Users.Add(new User("Мельников Святослав Администраторович", "Администратор",
                Roles.First(p => p.Name == "Администратор"), "admin", "123", Organizations[22]));
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
            dbContext.Roles.Add(new Role("Администратор", new Dictionary<string, string>
                {
                    {"Animal", "Mun;None"},
                    {"Organization", "Mun;3,4,5,6,8,9,10,11"},
                    {"MunicipalContract", "Mun;Mun"},
                    {"Statistics","Mun;Mun"},
                    {"Admin","All;All"}
                }));
            dbContext.SaveChanges();
        }

        private void FillAnimals()
        {
            var Localities = dbContext.Localities.ToList(); 
            dbContext.Animals.Add(new Animal("12345678912","Пёс", "М",2015,"987654321987","Бобик",new List<string>(){@"\dog1.jpg",}, "Белое пятно", "Красный поводок",Localities[2]));
            dbContext.Animals.Add(new Animal("65738591647", "Кошка","Ж",2019,"876543298127", "Маруся",new List<string>(){@"\cat1.jpg"},"Трёхцветный окрас","Отсутсвуют",Localities[0]));
            dbContext.Animals.Add(new Animal("87612349571","Собака","Ж",2020,"765826491738","Мухтар",new List<string>() { @"\dog2.jpg" },"Травмированные уши","Медальон на шее",Localities[1]));
            dbContext.Animals.Add(new Animal("37489061238","Кошка","Ж",2022,"237589173497","Анфиса",new List<string>(){@"\cat9.jpg"},"Чёрный хвост и чёрное пятно","Ошейник от блох",Localities[4]));
            dbContext.Animals.Add(new Animal("76385901639","Пёс","М",2012,"541096894315","Тузик",new List<string>(){@"\dog3.jpg"},"Шрам от ожога на лапе","Отсутсвуют",Localities[3]));
            
            dbContext.Animals.Add(new Animal("25489635178", "Собака", "М", 2014, "346958021679", "Лорд", new List<string>() { @"\dog4.jpg", }, "Чёрное пятно", "Медальон на шее", Localities[2]));
            dbContext.Animals.Add(new Animal("94125852658", "Кошка", "Ж", 2020, "264153895126", "Мышка", new List<string>() { @"\cat2.jpg"}, "Двухцветный окрас", "Отсутсвуют", Localities[4]));
            dbContext.Animals.Add(new Animal("95412756395", "Кот", "М", 2020, "254861935742", "Перс", new List<string>() { @"\cat3.jpg"}, "Травмированные уши", "Красный поводок", Localities[0]));
            dbContext.Animals.Add(new Animal("95418748526", "Пёс", "М", 2023, "259063105785", "Макс", new List<string>() { @"\dog5.jpg" }, "Чёрный хвост и чёрное пятно", "Отсутствуют", Localities[4]));
            dbContext.Animals.Add(new Animal("32568458256", "Кошка", "Ж", 2013, "541962053845", "Морка", new List<string>() { @"\cat4.jpg" }, "Чёрный кончик хвоста", "Ошейник от блох", Localities[1]));
            
            dbContext.Animals.Add(new Animal("55896854785", "Пёс", "М", 2016, "541985206348", "Рекс", new List<string>() { @"\dog6.jpg", }, "Белые лапы", "Отсутствуют", Localities[3]));
            dbContext.Animals.Add(new Animal("34619758226", "Кошка", "Ж", 2017, "578426956658", "Маруся", new List<string>() { @"\cat5.jpg"}, "Белый живот", "Отсутсвуют", Localities[0]));
            dbContext.Animals.Add(new Animal("34915826785", "Собака", "Ж", 2015, "632526988851", "Эля", new List<string>() { @"\dog7.jpg"}, "Травмированные уши", "Медальон на шее", Localities[0]));
            dbContext.Animals.Add(new Animal("50560159736", "Кот", "М", 2022, "201548765295", "Чили", new List<string>() { @"\cat6.jpg" }, "Чёрный окрас", "Ошейник от блох", Localities[1]));
            dbContext.Animals.Add(new Animal("64095731965", "Кот", "М", 2012, "316045895726", "Пушок", new List<string>() { @"\cat7.jpg" }, "Чёрный кончик хвоста", "Отсутсвуют", Localities[4]));
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
            dbContext.Organizations.Add(new Organization("ИП 'Рыбин А.П.'", "860912143819","546","ул. Белышева, 6",false,TypeOrganizations[5], Localities[2]));
            dbContext.Organizations.Add(new Organization("ОМСУ ГО город Тюмень","849625378921","874","ул. Беляшева, 66", true, TypeOrganizations[0], Localities[0]));
            dbContext.Organizations.Add(new Organization("ОМСУ ГО город Тобольск","264809538210","215", "ул. Комсомольская, 66",true,TypeOrganizations[0], Localities[1]));
            dbContext.Organizations.Add(new Organization("Приют для животных 'Лапочки'", "82549358625", "111", "ул. Балканская, д.3", true, TypeOrganizations[2], Localities[2]));
            dbContext.Organizations.Add(new Organization("Приют для животных 'Домик для хвостиков'", "24872695315", "125", "ул.  Славы, д.67", true, TypeOrganizations[2], Localities[0]));
            dbContext.Organizations.Add(new Organization("Приют для животных 'Счастливый лапушки'", "52984263526", "587", "ул. Будапештсткая, д.52", true, TypeOrganizations[8], Localities[3]));
            dbContext.Organizations.Add(new Organization("Приют для животных 'Заботливые лапки'", "54286520356", "741", "ул. Октябрьская, д.8", false, TypeOrganizations[5], Localities[0]));
            dbContext.Organizations.Add(new Organization("Приют для животных 'Любимые хвостики'", "54875129365", "596", "ул. Колхозная, д.45", true, TypeOrganizations[0], Localities[1]));
            dbContext.Organizations.Add(new Organization("Организация по отлову 'Чистые улицы'", "45528963215", "541", "ул. Калинина, д.47", true, TypeOrganizations[1], Localities[2]));
            dbContext.Organizations.Add(new Organization("Организация по отлову 'Безопасные лапки'", "20568549559", "147", "ул. Комсомольская, д.2", true, TypeOrganizations[4], Localities[3]));
            dbContext.Organizations.Add(new Organization("Организация по отлову 'Заботливые руки'", "84521025625", "968", "ул. Комсомольская, д.17", false, TypeOrganizations[6], Localities[3]));
            dbContext.Organizations.Add(new Organization("Организация по отлову 'Домашний ковчег'", "12365854205", "845", "ул. Дорожная, д.16", true, TypeOrganizations[9], Localities[0]));
            dbContext.Organizations.Add(new Organization("Организация по отлову 'Спасательные хвостики", "20568542625", "365", "ул. Космонавтов, д.5", true, TypeOrganizations[2], Localities[1]));
            dbContext.Organizations.Add(new Organization("Муниципальная ветеринарная клиника №18", "25896314785", "258", "ул. Кирова, д.55", false, TypeOrganizations[7], Localities[2]));
            dbContext.Organizations.Add(new Organization("Муниципальная ветеринарная клиника №2", "75395148624", "852", "ул. Трудовая, д.5", true, TypeOrganizations[7], Localities[3]));
            dbContext.Organizations.Add(new Organization("Частная вет. клиника 'Врачи на четырех лапах'", "96357415938", "145", "ул. Лесная, д.20", true, TypeOrganizations[8], Localities[3]));
            dbContext.Organizations.Add(new Organization("Частная вет. клиника 'Ветеринарный островок'", "85496325847", "369", "ул. Шоссейная, д.41", true, TypeOrganizations[8], Localities[0]));
            dbContext.Organizations.Add(new Organization("Частная вет. клиника 'Зоологическая больница'", "5846935218", "748", "ул. Победы, д.22", true, TypeOrganizations[8], Localities[2]));
            dbContext.Organizations.Add(new Organization("ОМСУ ГО город Ишим", "85967412458", "360", "ул. Первомайская, д.65", true, TypeOrganizations[0], Localities[3]));
            dbContext.Organizations.Add(new Organization("ОМСУ ГО город Нижняя Тавда", "14258675935", "256", "ул. Светлая, д.25", true, TypeOrganizations[0], Localities[4]));
            dbContext.Organizations.Add(new Organization("ИП 'Васильев И.Н.'", "14532685945", "326", "ул. Чапаева, д.21", true, TypeOrganizations[8], Localities[0]));
            dbContext.Organizations.Add(new Organization("ИП 'Никитин К.П.'", "78459632145", "485", "ул. Чапаева, д.30", true, TypeOrganizations[7], Localities[0]));
            dbContext.Organizations.Add(new Organization("ИП 'Рютин Е.Н.'", "25471869543", "214", "ул. Заводская, д.40", true, TypeOrganizations[9], Localities[3]));
            dbContext.Organizations.Add(new Organization("ИП 'Липин Д.Д.'", "25478965132", "693", "ул. Трудовая, д.20", true, TypeOrganizations[9], Localities[3]));
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
