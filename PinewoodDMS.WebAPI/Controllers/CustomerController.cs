using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PinewoodDMS.DataAccessLayer.Repositories;
using PinewoodDMS.Models.Models;

namespace PinewoodDMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _customerRepository.All();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(Guid id)
        {
            if (_customerRepository.Get(id) == null)
                return NotFound();
            return Ok(_customerRepository.Get(id));
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] Customer newCustomer)
        {
            var newAddedCustomer = _customerRepository.Add(newCustomer);
            return Ok(newAddedCustomer);
        }


        [HttpPut("{id}")]
        public ActionResult EditCustomer(Guid id, [FromBody] Customer updatedCustomer)
        {
            var customer = _customerRepository.Get(id);
            if (customer == null)
                return NotFound();


            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.AddressLine1 = updatedCustomer.AddressLine1;
            customer.AddressLine2 = updatedCustomer.AddressLine2;
            customer.Country = updatedCustomer.Country;
            customer.City = updatedCustomer.City;
            customer.Telephone = updatedCustomer.Telephone;
            customer.HouseNumber = updatedCustomer.HouseNumber;
            customer.Email = updatedCustomer.Email;
            customer.PostalCode = updatedCustomer.PostalCode;
            _customerRepository.Update(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCustomer(Guid id)
        {

            var customer = _customerRepository.Get(id);
            if (customer == null)
                return NotFound();

            _customerRepository.Remove(customer);
            return Ok();
        }


    }
}
