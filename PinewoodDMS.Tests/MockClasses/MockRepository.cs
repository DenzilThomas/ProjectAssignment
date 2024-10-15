using Moq;
using PinewoodDMS.DataAccessLayer.Repositories;
using PinewoodDMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodDMS.Tests.MockClasses
{
    public class MockRepository
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customers = new List<Customer> { new Customer { FirstName = "Kelly", LastName = "Rose", HouseNumber = "44", AddressLine1 = "Church Lane", AddressLine2 = "Winsor Gardens", Telephone = "07888543215", Email = "Kelly.Rose@yahoo.com", City = "Oxford", PostalCode = "OX12 5ED", Country = "United Kingdom" },
        new Customer { FirstName = "Rita", LastName = "Ross", HouseNumber = "33", AddressLine1 = "High Street", AddressLine2 = "Nightingale Area", Telephone = "07672543234", Email = "Rita.Ross@outlook.com", City = "Warwick", PostalCode = "CV23 5ED", Country = "United Kingdom" },
        new Customer { FirstName = "Tim", LastName = "Roton", HouseNumber = "56", AddressLine1 = "Evan close", AddressLine2 = "Jephons", Telephone = "07634543234", Email = "Tim.Roton @gmail.com", City = "London", PostalCode = "L12 5ED", Country = "United Kingdom" }
        };

            var customer = new Customer() { FirstName = "Amanda", LastName = "Smith", HouseNumber = "12A", AddressLine1 = "Church Lane", AddressLine2 = "Winsor Gardens", Telephone = "07888543215", Email = "Amanda.Smith@yahoo.com", City = "Oxford", PostalCode = "OX12 5ED", Country = "United Kingdom" };

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            mockCustomerRepository.Setup(repo => repo.All()).Returns(customers);
            mockCustomerRepository.Setup(repo => repo.Add(customer)).Returns(customer);
            mockCustomerRepository.Setup(repo => repo.Remove(customer)).Returns(customer);
            mockCustomerRepository.Setup(repo => repo.Update(customer)).Returns(customer);
            mockCustomerRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(customers[0]);
            return mockCustomerRepository;

        }
    }
}
