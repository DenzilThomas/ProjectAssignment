using Microsoft.AspNetCore.Mvc;
using PinewoodDMS.Models.Models;
using PinewoodDMS.Tests.MockClasses;
using PinewoodDMS.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodDMS.Tests.controllers
{
  
    public class CustomerControllerTest
    {

        [Fact]
        public void GetAllCustomers_ReturnsAllCustomers()
        {
            //arrange
            var mockCustomerRepository = MockRepository.GetCustomerRepository();

            var customerController = new CustomerController(mockCustomerRepository.Object);

            //act
            var result = customerController.GetAllCustomers();

            //assert
            var actionResult = Assert.IsType<ActionResult<List<Customer>>>(result);
            var customerList = Assert.IsAssignableFrom<List<Customer>>((result?.Result as ObjectResult)?.Value);
            Assert.Equal(3, customerList.Count());

        }

        [Fact]
        public void GetCustomerById_ReturnsACustomer()
        {
            //arrange
            var mockCustomerRepository = MockRepository.GetCustomerRepository();

            var customerController = new CustomerController(mockCustomerRepository.Object);

            //act
            var result = customerController.GetById(Guid.Parse("4bc34cb4-c16e-4172-97af-4f90d2c494ec"));

            //assert
            var actionResult = Assert.IsType<ActionResult<Customer>>(result);
            var customer = Assert.IsAssignableFrom<Customer>((result?.Result as ObjectResult).Value);
            Assert.Equal("Kelly", customer.FirstName);

        }

    }
}
