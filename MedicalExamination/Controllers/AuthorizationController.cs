using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MedicalExamination.Services;

namespace MedicalExamination.Controllers
{
    public class AuthorizationController
    {
        HttpClient client = HttpProvider.GetInstance().httpClient;

        public bool GetResultCheckAuthorization(string login, string password)
        {
            return new AuthorizationService().CheckAuthorization(login, password); 
        }

        public Dictionary<string, string> AuthorizeAndRetrievePrivileges(string login, string password)
        {
            HttpResponseMessage response = client.GetAsync($"ME/Authorization/{login}/{password}").Result;

            //случай когда логин или пароль неправильный 
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            var privileges = JsonConvert
                .DeserializeObject<Dictionary<string, string>>(response.Content.ReadAsStringAsync().Result);

            return privileges;
        }

        public void SetPrivileges(Dictionary<string, string> dict)
        {
            PrivilegeService.Privileges = dict;
        }
    }
}
