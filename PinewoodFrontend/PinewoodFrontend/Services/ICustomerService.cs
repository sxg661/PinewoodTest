using PinewoodFrontend.Shared;

namespace PinewoodFrontend.Services
{
    public interface ICustomerService
    {
		Task<IEnumerable<Customer>> GetCustomers();
	}
}
