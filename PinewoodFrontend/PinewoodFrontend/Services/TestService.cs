
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
            HttpResponseMessage response = null;

            try
            {
				response = await httpClient.GetAsync("/Test");
			}
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var message = await response.Content.ReadAsStringAsync();

            return message;
        }
    }
}
