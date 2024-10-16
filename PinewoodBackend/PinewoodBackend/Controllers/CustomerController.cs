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
		private ActionResult badIdResult;
		private ActionResult notFoundResult;

		public CustomerController(ICustomerService customerService)
		{
			this.customerService = customerService;
			badIdResult = StatusCode(400, "Id should be an integer");
			notFoundResult = StatusCode(404, "Customer not found");
		}

		[HttpGet(Name = "GetAll")]
		public string GetAllCustomers()
		{
			return JsonSerializer.Serialize(customerService.GetAllCustomers());
		}

		[HttpGet("{id}", Name = "GetById")]
		public ActionResult GetCustomer(string id)
		{
			if (!int.TryParse(id, out int intId))
			{
				return badIdResult;
			}

			if (customerService.GetCustomerByID(intId) == null)
			{
				return notFoundResult;
			}

			var customer = customerService.GetCustomerByID(intId);

			if (customer == null)
			{
				return notFoundResult;
			}

			var customerJson = JsonSerializer.Serialize(customer);
			return Content(customerJson);
		}

		[HttpPost(Name = "Create")]
		public ActionResult CreateCustomer(string firstName, string lastName, DateTime dob)
        {
            customerService.AddNewCustomer(firstName, lastName, dob);
            return StatusCode(200, "Creation successful");
        }

        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult DeleteCustomer(string id)
        {
			if(!int.TryParse(id, out int intId))
			{
				return badIdResult;
			}

			if(customerService.GetCustomerByID(intId) == null)
			{
				return notFoundResult;
			}

			customerService.DeleteCustomer(intId);
			return StatusCode(200, "Deletion successful");
		}

        [HttpPatch("{id}", Name = "Modify")]
		public ActionResult ModifyCustomer(string id, string firstName, string lastName, DateTime dob)
		{
			if (!int.TryParse(id, out int intId))
			{
				return badIdResult;
			}

			if (customerService.GetCustomerByID(intId) == null)
			{
				return notFoundResult;
			}

			customerService.ModifyCustomer(intId, firstName, lastName, dob);
			return StatusCode(200, "Modification successful");
		}
	}
}
