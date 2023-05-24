﻿using System;
using System.Collections.Generic;
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

        static TestData()
        {
            FillMunicipalities();
            FillLocalities();
            FillTypeOrganizations();
            FillOrganizations();
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
        }
    }
}
