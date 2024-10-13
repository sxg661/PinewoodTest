using PinewoodBackend.Shared;

namespace PinewoodBackend.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer? GetCustomerByID(string id);
        public void AddNewCustomer(string firstName, string lastName, DateTime dob);
        public void DeleteCustomer(string id);
        public bool ModifyCustomer(string id, string firstName, string lastName, DateTime dob);
    }
}
