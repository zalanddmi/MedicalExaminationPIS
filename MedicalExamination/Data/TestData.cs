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
        Dictionary<int, Locality> localities = new Dictionary<int, Locality>();
        Dictionary<int, TypeOrganization> typeOrganizations = new Dictionary<int, TypeOrganization>();
        Dictionary<int, Organization> organizations = new Dictionary<int, Organization>();

        public TestData()
        {
            FillLocalities();
            FillTypeOrganizations();
        }

        private void FillLocalities()
        {
            localities.Add(1, new Locality("Тюмень"));
            localities.Add(2, new Locality("Тобольск"));
            localities.Add(3, new Locality("Менделеево"));
            localities.Add(4, new Locality("Ишим"));
            localities.Add(5, new Locality("Нижняя Тавда"));
        }

        private void FillTypeOrganizations()
        {
            typeOrganizations.Add(1, new TypeOrganization("Исполнительный орган государственной власти"));
            typeOrganizations.Add(2, new TypeOrganization("Орган местного самоуправления"));
            typeOrganizations.Add(3, new TypeOrganization("Приют"));
            typeOrganizations.Add(4, new TypeOrganization("Организация по отлову"));
            typeOrganizations.Add(5, new TypeOrganization("Организация по отлову и приют"));
            typeOrganizations.Add(6, new TypeOrganization("Организация по транспортировке"));
            typeOrganizations.Add(7, new TypeOrganization("Ветеринарная клиника: государственная"));
            typeOrganizations.Add(8, new TypeOrganization("Ветеринарная клиника: муниципальная"));
            typeOrganizations.Add(9, new TypeOrganization("Ветеринарная клиника: частная"));
            typeOrganizations.Add(10, new TypeOrganization("Благотворительный фонд"));
            typeOrganizations.Add(11, new TypeOrganization("Организации по продаже товаров и предоставлению услуг для животных"));
            typeOrganizations.Add(12, new TypeOrganization("Заявитель"));
        }

        private void FillOrganizations()
        {
            organizations.Add(1, new Organization(
                "Приют для животных 'Добрый дом'",
                "1234567890",
                "123",
                "ул. Лесная, д.10",
                true,
                typeOrganizations[3],
                localities[1]));
            organizations.Add(2, new Organization(
                "Организация по отлову животных 'Улов'",
                "5678901234",
                "567",
                "ул. Красноармейская, д.50",
                true,
                typeOrganizations[4],
                localities[1]));
            organizations.Add(3, new Organization(
                "Муниципальная ветеринарная клиника №1",
                "7890123456",
                "789",
                "ул. Садовая, д.15",
                true,
                typeOrganizations[8],
                localities[1]));
            organizations.Add(4, new Organization(
                "Частная ветеринарная клиника 'Ветеринар'",
                "9012345678",
                "901",
                "ул. Красная, д.25",
                true,
                typeOrganizations[9],
                localities[2]));
            organizations.Add(5, new Organization(
                "ИП 'Рыбин А.П.'",
                "860912143819",
                "860901001",
                "ул. Белышева, 6",
                false,
                typeOrganizations[6],
                localities[3]));
        }
    }
}
