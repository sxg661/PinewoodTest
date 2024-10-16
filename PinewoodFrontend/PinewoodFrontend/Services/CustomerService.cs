
using PinewoodFrontend.Shared;
using System.Globalization;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

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
				return [];
			}
		}

		public async Task<Customer?> GetCustomerById(int customerId)
		{
			var response = await httpClient.GetAsync($"/Customer/{customerId}");
			var responseText = await response.Content.ReadAsStringAsync();

			try
			{
				return JsonSerializer.Deserialize<Customer>(responseText);
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		private string BuildQueryString(string firstName, string lastName, DateTime dateOfBirth)
		{
			var query = HttpUtility.ParseQueryString(string.Empty);
			query["firstName"] = firstName;
			query["lastName"] = lastName;
			query["dob"] = dateOfBirth.ToString("d", CultureInfo.CreateSpecificCulture("en-US"));
			string? queryString = query.ToString();
			return queryString != null ? queryString : "";
		}

		public async Task<bool> CreateCustomer(string firstName, string lastName, DateTime dateOfBirth)
		{
			string queryString = BuildQueryString(firstName, lastName, dateOfBirth);
			string url = "/Customer?" + queryString;

			var response = await httpClient.PostAsync(url, new StringContent(""));

			var status = (int) response.StatusCode;

			return status == 200;
		}

		public async Task<bool> ModifyCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth)
		{
			string queryString = BuildQueryString(firstName, lastName, dateOfBirth);
			string url = $"/Customer/{customerId}?" + queryString;

			var response = await httpClient.PatchAsync(url, new StringContent(""));

			var status = (int) response.StatusCode;

			return status == 200;
		}

		public async Task<bool> DeleteCustomer(int customerId)
		{
			try
			{
				var response = await httpClient.DeleteAsync($"Customer/{customerId}");
                return (int)response.StatusCode == 200;
            }
			catch(Exception ex)
			{
				return false;
			}
		}
	}
}
