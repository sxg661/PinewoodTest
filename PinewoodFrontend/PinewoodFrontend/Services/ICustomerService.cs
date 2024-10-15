using PinewoodFrontend.Shared;

namespace PinewoodFrontend.Services
{
    public interface ICustomerService
    {
		Task<IEnumerable<Customer>> GetCustomers();
		Task<Customer?> GetCustomerById(string customerId);
		Task<bool> CreateCustomer(string firstName, string lastName, DateTime dateOfBirth);
		Task<bool> ModifyCustomer(string customerId, string firstName, string lastName, DateTime dateOfBirth);
		Task<bool> DeleteCustomer(string customerId);
	}
}
