using PinewoodBackend.Shared;
using System.Text.Json;

namespace PinewoodBackend.Services
{
    public class CustomerService : ICustomerService
    {
        public static string FILENAME = "customers.json";

        public List<Customer> customers;

        public CustomerService()
        {
            customers = LoadFromFile();
        }
        private string NewId()
        {
            return Guid.NewGuid().ToString();
        }

        private List<Customer> LoadFromFile()
        {
            var jsonString = File.ReadAllText(FILENAME);

            var customersFromFile = JsonSerializer.Deserialize<List<Customer>>(jsonString);

            if(customersFromFile == null)
            {
                throw new Exception("Could not read json customer file");
            }

            return customersFromFile;
        }

        private void SaveToFile()
        {
            var customerJson = JsonSerializer.Serialize(customers);

            File.WriteAllText(FILENAME, customerJson);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }
        public Customer? GetCustomerByID(string id)
        {
            var customer = customers.FirstOrDefault((customer) => customer.Id == id);

            return customer;
        }

        public void AddNewCustomer(string firstName, string lastName, DateTime dob)
        {
            var newCustomer = new Customer
            {
                Id = NewId(),
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob
            };

            customers.Add(newCustomer);
            SaveToFile();
        }

        public void DeleteCustomer(string id)
        {
            customers.RemoveAll((item) => item.Id == id);
            SaveToFile();
        }

        public bool ModifyCustomer(string id, string firstName, string lastName, DateTime dob)
        {
            var customer = customers.FirstOrDefault((customer) => customer.Id == id);

            if (customer == null)
            {
                return false;
            }
            
            customer.Id = id;
            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.DateOfBirth = dob;

            SaveToFile();

            return true;
        }
    }
}
