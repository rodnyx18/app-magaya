using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MWebApi.Contexts;
using MWebApi.Entities;
using MWebApi.Exceptions;
using MWebApi.Repositories;
using MWebApi.Test.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWebApi.Test.RepositoriesTest
{
    public class CustomerRepositoryTest
    {
        private static readonly DbContextOptions<OrdersDBContext> dbContextOptions = 
            new DbContextOptionsBuilder<OrdersDBContext>()
             .UseInMemoryDatabase(databaseName: "OrdersDb")
             .Options;

        OrdersDBContext _context = default!;
        CustomerRepository _repository = default!;

        [OneTimeSetUp]
        public void InitializeDB()
        { 
            _context = new OrdersDBContext(dbContextOptions);
            _context.Database.EnsureCreated();
            FillDataBase();        
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [SetUp]
        public void Setup()
        {
            _repository = new CustomerRepository(_context);
        }  

        [Test]
        public async Task GetCustomer_WhenCustomerExists_MustReturnCustomer()
        {
            // Arrange            
            var customer1 = _context.Customers.FirstAsync(c => c.Id == 1).Result;

            // Action
            var result = await _repository.Get(1);

            // Assert            
            result.Should().BeEquivalentTo(customer1);
        }

        [Test]
        public void AddCustomer_WhenEmailIsInUse_MustReturnFunctionalException()
        {
            // Arrange
            var customer1 = _context.Customers.FirstAsync(c => c.Id == 1).Result;
            var customer2 = Generator.CreateCustomer();
            customer2.Id = 2;
            customer2.AddressId = 1;
            customer2.Email = customer1.Email;

            // Action
            var ex = Assert.ThrowsAsync<FunctionalException>(async () => await _repository.Add(customer2));

            // Assert            
            ex?.Message.Should().Be("Customer cannot be created: Email is already in use.");
            ex?.ErrorCode.Should().Be(403);
        }

        private void FillDataBase()
        {
            var address = Generator.CreateAddress();
            address.Id = 1;
            var customer = Generator.CreateCustomer();
            customer.Id = 1;
            customer.AddressId = 1;

            _context.Addresses.Add(address);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}
