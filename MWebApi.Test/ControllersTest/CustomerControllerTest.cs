using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using MWebApi.Controllers;
using MWebApi.Dtos.Reponse;
using MWebApi.Entities;
using MWebApi.Mapping;
using MWebApi.Repositories;
using MWebApi.Test.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MWebApi.Test
{
    public class Tests
    {
        Mock<ICustomerRepository> _customerRepository = default!;
        CustomerController _controller = default!;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _controller = new CustomerController(_customerRepository.Object);
        }

        [Test]
        public async Task GetCustomer_WhenCustomerDoesNotExists_MustReturnNotFound()
        {
            // Arrange
            Customer? customer = default!;          
            _customerRepository
                .Setup(c => c.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(customer));
           
            // Action
            var response = await _controller.GetCustomer(1);

            // Assert
            Assert.AreEqual(404, ((NotFoundResult)response!.Result!).StatusCode);
        }

        [Test]
        public async Task GetCustomer_WhenCustomerExists_MustReturnCustomerReponse()
        {
            // Arrange
            var address = Generator.CreateAddress();
            var customer = Generator.CreateCustomer();
            customer.Address = address;
            int customerId = customer.Id;  
            
            _customerRepository
                .Setup(c => c.Get(customerId))
                .Returns(Task.FromResult(customer));

            // Action
            var response = await _controller.GetCustomer(customerId);

            // Assert
            var responseObject = ((OkObjectResult)response!.Result!).Value;
            responseObject.Should().BeEquivalentTo(customer.ToCustomerReponse());
        }
    }
}