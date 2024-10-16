using PinewoodBackend.Database;
using System.Text.Json;

namespace PinewoodBackend.Services
{
    public class CustomerServiceJson : ICustomerService
    {
        public static string FILENAME = "customers.json";

        public List<Customer> customers;

        public CustomerDbContext dbContext;

        public CustomerServiceJson()
        {
            customers = LoadFromFile();
            dbContext = new CustomerDbContext();
        }
        private int NewId()
        {
            return customers.Count > 0 ? customers.Max(customer => customer.Id) + 1 : 0;
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
        public Customer? GetCustomerByID(int id)
        {
			var customer = customers.FirstOrDefault((customer) => customer.Id == id);
            return customer;
        }

        public bool AddNewCustomer(string firstName, string lastName, DateTime dob)
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
            return true;
        }

        public bool DeleteCustomer(int id)
        {
			customers.RemoveAll((customer) => customer.Id == id);
			SaveToFile();
            return true;
		}

        public bool ModifyCustomer(int id, string firstName, string lastName, DateTime dob)
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
