using PinewoodFrontend.Shared;

namespace PinewoodFrontend.Services
{
    public interface ICustomerService
    {
		Task<IEnumerable<Customer>> GetCustomers();
		Task<Customer?> GetCustomerById(int customerId);
		Task<bool> CreateCustomer(string firstName, string lastName, DateTime dateOfBirth);
		Task<bool> ModifyCustomer(int customerId, string firstName, string lastName, DateTime dateOfBirth);
		Task<bool> DeleteCustomer(int customerId);
	}
}
