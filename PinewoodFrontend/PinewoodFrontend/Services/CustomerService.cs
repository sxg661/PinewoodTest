
using PinewoodFrontend.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace PinewoodFrontend.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly HttpClient httpClient;

		public CustomerService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<IEnumerable<Customer>> GetCustomers()
		{
			var response = await httpClient.GetAsync("/Customer");
			var responseText = await response.Content.ReadAsStringAsync();

			try
			{
				var customers = JsonSerializer.Deserialize<Customer[]>(responseText);
				return customers != null ? customers : [];
			}
			catch (Exception ex)
			{
				int y = 5;
				return [];
			}
		}
	}
}
