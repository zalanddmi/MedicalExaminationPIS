using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerME.Data;
using ServerME.Models;
using ServerME.Utils;

namespace ServerME.Services
{
    public class OrganizationsService
    {
        private PrivilegeService service = new PrivilegeService();
        private OrganizationsRepository repository;
        public OrganizationsService()
        {
            repository = new OrganizationsRepository(); 
        }

        public List<string[]> MapOrganizations(List<Organization> gotOrganizations)
        {
            var organizations = new List<string[]>();
            foreach (var gotOrganization in gotOrganizations)
            {
                var organization = new List<string>
                {
                    gotOrganization.IdOrganization.Value.ToString(),
                    gotOrganization.Name,
                    gotOrganization.TaxIdNumber,
                    gotOrganization.CodeReason,
                    gotOrganization.Address,
                    gotOrganization.TypeOrganization.Name,
                    gotOrganization.IsJuridicalPerson ? "Юрлицо" : "ИП",
                    gotOrganization.Locality.Name
                };
                organizations.Add(organization.ToArray());
            }
            return organizations;
        }

        public string[] MapOrganization(Organization organization)
        {
            var organizationList = new List<string>
            {
                organization.Name,
                organization.TaxIdNumber,
                organization.CodeReason,
                organization.Address,
                organization.TypeOrganization.Name,
                organization.IsJuridicalPerson ? "Юрлицо" : "ИП",
                organization.Locality.Name
            };
            return organizationList.ToArray();
        }

        public List<string[]> GetOrganizations(string filter, string sorting, int currentPage, int pageSize, User user)
        {
            var privilege = service.SetPrivilegeForUser(user);
            var gotOrganizations = repository.GetOrganizations(filter, sorting, privilege, currentPage, pageSize);
            var organizations = MapOrganizations(gotOrganizations);
            return organizations;
        }

        public List<Organization> GetOrganizationsForContract(User user)
        {
            var privilege = service.SetPrivilegeForUser(user);
            var organizations = repository.GetOrganizationsForContract(privilege);
            return organizations;
        }

        public List<Organization> GetOrganizationsForReport(User user)
        {
            return repository.GetOrganizationsForReport(user);
        }

        public Organization GetOrganizationCardToView(int organizationId)
        {
            var organization = repository.GetOrganization(organizationId);
            return organization;
        }
        public void MakeOrganization(Organization organization, User user)
        {
            var resultCheck = service.CheckUserForOrganization(user);
            if (!resultCheck)
                throw new InvalidOperationException();
            
            repository.AddOrganization(user, organization);

        }

        public void EditOrganization(Organization organization, User user)
        {
            var resultCheck = service.CheckOrganizationForUser(organization.IdOrganization.Value, user);
            if (resultCheck)
            {
                repository.UpdateOrganization(user, organization);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public byte[] GetExcelByteArrayFormat(string filter, string sorting, User user)
        {
            string[] columnNames = new string[] {"Название",
                "ИНН", "КПП", "Адрес регистрации", "Тип организиции",
                "ИП/Юрлицо", "Населенный пункт" };

            var organizations = GetOrganizations(filter, sorting, 1, int.MaxValue, user);

            return ExcelConverter.GenerateExcelFile(organizations, columnNames);
        }

        public void DeleteOrganization(int organizationId, User user)
        {
            var resultCheck = service.CheckOrganizationForUser(organizationId, user);
            if (resultCheck)
            {
                repository.DeleteOrganization(user, organizationId);
            }
            else
            {
                throw new InvalidOperationException("У вас нет прав, чтобы удалить!");
            }
        }

    }
}
