using System;
using System.Net.Http;

namespace MedicalExamination.Controllers
{
    public class HttpProvider
    {
        private static HttpProvider httpProvider;
        public HttpClient httpClient { get; private set; }
        private HttpProvider()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5109/");
        }

        public static HttpProvider GetInstance()
        {
            if (httpProvider is null)
                httpProvider = new HttpProvider();
            
            return httpProvider;
        }
    }
}
