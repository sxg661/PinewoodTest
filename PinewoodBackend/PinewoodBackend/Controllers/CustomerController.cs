using Microsoft.AspNetCore.Mvc;
using PinewoodBackend.Entity;
using System.Text.Json;

namespace PinewoodBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private void AddNewCustomer(string firstName, string lastName, DateTime dob)
        {
            var newCustomer = new Customer
            {
                Id = Customer.NewId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dob
            };

            Customer.customers.Add(newCustomer);
        }

		[HttpGet(Name = "GetAll")]
		public IEnumerable<string> GetAllCustomers()
		{
            return Customer.customers.Select((customer) => {
                var customerJson = JsonSerializer.Serialize(customer);
                return customerJson;
            });
		}

		[HttpGet("{id}", Name = "GetById")]
		public ActionResult GetCustomer(string id)
		{
			var customer = Customer.customers.FirstOrDefault((customer) => customer.Id == id);

			if(customer == null)
			{
				return StatusCode(404, "Customer not found");
			}

			var customerJson = JsonSerializer.Serialize(customer);
			return Content(customerJson);
		}

		[HttpPut(Name = "Create")]
		public ActionResult CreateCustomer(string firstName, string lastName, DateTime dob)
        {
            AddNewCustomer(firstName, lastName, dob);
            return StatusCode(200);
        }

		[HttpPatch("{id}", Name = "Modify")]
		public ActionResult ModifyCustomer(string id, string firstName, string lastName, DateTime dob)
		{
			var customer = Customer.customers.FirstOrDefault((customer) => customer.Id == id);

			if (customer == null)
			{
				return StatusCode(404, "Customer not found");
			}

			customer.Id = id;
			customer.FirstName = firstName;
			customer.LastName = lastName;
			customer.DateOfBirth = dob;

			return StatusCode(200);
		}

		[HttpDelete(Name = "Delete")]
		public ActionResult DeleteCustomer(string id)
		{
            Customer.customers.RemoveAll((item) => item.Id == id);
			return StatusCode(200);
		}
	}
}
