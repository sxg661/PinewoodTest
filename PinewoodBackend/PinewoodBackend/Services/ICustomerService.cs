using PinewoodBackend.Database;

namespace PinewoodBackend.Services
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetAllCustomers();
        public Customer? GetCustomerByID(int id);
        public bool AddNewCustomer(string firstName, string lastName, DateTime dob);
        public bool DeleteCustomer(int id);
        public bool ModifyCustomer(int id, string firstName, string lastName, DateTime dob);
    }
}
