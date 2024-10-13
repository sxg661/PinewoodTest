using Microsoft.AspNetCore.Mvc;
using PinewoodBackend.Services;
using System.Text.Json;

namespace PinewoodBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
		private ICustomerService customerService;
		public CustomerController(ICustomerService customerService)
		{
			this.customerService = customerService;
		}

		[HttpGet(Name = "GetAll")]
		public string GetAllCustomers()
		{
			return JsonSerializer.Serialize(customerService.GetAllCustomers());
		}

		[HttpGet("{id}", Name = "GetById")]
		public ActionResult GetCustomer(string id)
		{
			var customer = customerService.GetCustomerByID(id);

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
            customerService.AddNewCustomer(firstName, lastName, dob);
            return StatusCode(200, "Creation successful");
        }

        [HttpDelete(Name = "Delete")]
        public ActionResult DeleteCustomer(string id)
        {
            customerService.DeleteCustomer(id);
            return StatusCode(200, "Deletion successful");
        }

        [HttpPatch("{id}", Name = "Modify")]
		public ActionResult ModifyCustomer(string id, string firstName, string lastName, DateTime dob)
		{
			var success = customerService.ModifyCustomer(id, firstName, lastName, dob);

			return success ? StatusCode(200, "Modification successful") : StatusCode(404, "Customer not found");
		}
	}
}
