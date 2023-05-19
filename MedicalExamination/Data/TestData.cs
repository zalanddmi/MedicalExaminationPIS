using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExamination.Models;

namespace MedicalExamination.Data
{
    public class TestData
    {
        public Dictionary<int, Municipality> Municipalities = new Dictionary<int, Municipality>();
        public Dictionary<int, Locality> Localities = new Dictionary<int, Locality>();
        public Dictionary<int, TypeOrganization> TypeOrganizations = new Dictionary<int, TypeOrganization>();
        public Dictionary<int, Organization> Organizations = new Dictionary<int, Organization>();

        public TestData()
        {
            FillMunicipalities();
            FillLocalities();
            FillTypeOrganizations();
            FillOrganizations();
        }

        private void FillMunicipalities()
        {
            Municipalities.Add(1, new Municipality("Городской округ город Тюмень"));
            Municipalities.Add(2, new Municipality("Городской округ город Тобольск"));
            Municipalities.Add(3, new Municipality("Городской округ город Ишим"));
            Municipalities.Add(4, new Municipality("Нижнетавдинский муниципальный район"));
        }

        private void FillLocalities()
        {
            Localities.Add(1, new Locality("г. Тюмень", Municipalities[1]));
            Localities.Add(2, new Locality("г. Тобольск", Municipalities[2]));
            Localities.Add(3, new Locality("р.п. Сумкино", Municipalities[2]));
            Localities.Add(4, new Locality("г. Ишим", Municipalities[3]));
            Localities.Add(5, new Locality("г. Нижняя Тавда", Municipalities[4]));
        }

        private void FillTypeOrganizations()
        {
            TypeOrganizations.Add(1, new TypeOrganization("Исполнительный орган государственной власти"));
            TypeOrganizations.Add(2, new TypeOrganization("Орган местного самоуправления"));
            TypeOrganizations.Add(3, new TypeOrganization("Приют"));
            TypeOrganizations.Add(4, new TypeOrganization("Организация по отлову"));
            TypeOrganizations.Add(5, new TypeOrganization("Организация по отлову и приют"));
            TypeOrganizations.Add(6, new TypeOrganization("Организация по транспортировке"));
            TypeOrganizations.Add(7, new TypeOrganization("Ветеринарная клиника: государственная"));
            TypeOrganizations.Add(8, new TypeOrganization("Ветеринарная клиника: муниципальная"));
            TypeOrganizations.Add(9, new TypeOrganization("Ветеринарная клиника: частная"));
            TypeOrganizations.Add(10, new TypeOrganization("Благотворительный фонд"));
            TypeOrganizations.Add(11, new TypeOrganization("Организации по продаже товаров и предоставлению услуг для животных"));
            TypeOrganizations.Add(12, new TypeOrganization("Заявитель"));
        }

        private void FillOrganizations()
        {
            Organizations.Add(1, new Organization(
                "Приют для животных 'Добрый дом'",
                "1234567890",
                "123",
                "ул. Лесная, д.10",
                true,
                TypeOrganizations[3],
                Localities[1]));
            Organizations.Add(2, new Organization(
                "Организация по отлову животных 'Улов'",
                "5678901234",
                "567",
                "ул. Красноармейская, д.50",
                true,
                TypeOrganizations[4],
                Localities[1]));
            Organizations.Add(3, new Organization(
                "Муниципальная ветеринарная клиника №1",
                "7890123456",
                "789",
                "ул. Садовая, д.15",
                true,
                TypeOrganizations[8],
                Localities[1]));
            Organizations.Add(4, new Organization(
                "Частная ветеринарная клиника 'Ветеринар'",
                "9012345678",
                "901",
                "ул. Красная, д.25",
                true,
                TypeOrganizations[9],
                Localities[2]));
            Organizations.Add(5, new Organization(
                "ИП 'Рыбин А.П.'",
                "860912143819",
                "860901001",
                "ул. Белышева, 6",
                false,
                TypeOrganizations[6],
                Localities[3]));
        }
    }
}
