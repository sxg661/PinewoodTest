using PinewoodBackend.Database;

namespace PinewoodBackend.Services
{
    public class CustomerServiceDb : ICustomerService
    {
        public CustomerDbContext customerDbContext;

        public CustomerServiceDb()
        {
            customerDbContext = new CustomerDbContext();
        }

		public bool AddNewCustomer(string firstName, string lastName, DateTime dob)
		{
			customerDbContext.Add(new Customer
			{
				FirstName = firstName,
				LastName = lastName,
				DateOfBirth = dob
			});
			customerDbContext.SaveChanges();
			return true;
		}

		public bool DeleteCustomer(int id)
		{
			var customer = customerDbContext.Customers.FirstOrDefault(c => c.Id == id);
			if(customer != null)
			{
				customerDbContext.Remove(customer);
				customerDbContext.SaveChanges();
				return true;
			}
			return false;
		}

		public IEnumerable<Customer> GetAllCustomers()
		{
			return [.. customerDbContext.Customers];
		}

		public Customer? GetCustomerByID(int id)
		{
			return customerDbContext.Customers.FirstOrDefault(c => c.Id == id);
		}

		public bool ModifyCustomer(int id, string firstName, string lastName, DateTime dob)
		{
			var customer = customerDbContext.Customers.FirstOrDefault(c => c.Id == id);
			if (customer != null)
			{
				customer.FirstName = firstName;
				customer.LastName = lastName;
				customer.DateOfBirth = dob;
				customerDbContext.Customers.Update(customer);
				customerDbContext.SaveChanges();
			}
			return false;
		}
	}
}
