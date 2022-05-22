using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MWebApi.Contexts;
using MWebApi.Entities;
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
        private static readonly DbContextOptions<OrdersDBContext> dbContextOptions = new DbContextOptionsBuilder<OrdersDBContext>()
        .UseInMemoryDatabase(databaseName: "OrdersDb")
        .Options;

        OrdersDBContext _context = default!;
        CustomerRepository _repository = default!;
        Customer _customer1 = default!;

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
            var repository = new CustomerRepository(_context);

            // Action
            var result = await repository.Get(1);

            // Assert
            Assert.IsNotNull(result);
            result.Should().BeEquivalentTo(_customer1);
        }

        private void FillDataBase()
        {
            var address = Generator.CreateAddress();
            address.Id = 1;
            _customer1 = Generator.CreateCustomer();
            _customer1.Id = 1;
            _customer1.AddressId = 1;

            _context.Addresses.Add(address);
            _context.Customers.Add(_customer1);
            _context.SaveChanges();
        }
    }
}
