
using System.Net.Http.Json;

namespace PinewoodFrontend.Services
{
    public class TestService : ITestService
    {
        private readonly HttpClient httpClient;

        public TestService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> GetMessage()
        {
			var response = await httpClient.GetAsync("/Test");

            var message = await response.Content.ReadAsStringAsync();

            return message;
        }
    }
}
