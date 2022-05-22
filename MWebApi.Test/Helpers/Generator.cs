using AutoFixture;
using MWebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MWebApi.Test.Helpers
{
    public static class Generator
    {
        public static Address CreateAddress()
        {
            return new Fixture()
                  .Build<Address>()
                  .Without(a => a.Customers)
                  .Create();
        }

        public static Customer CreateCustomer()
        {
            return new Fixture()
                  .Build<Customer>()
                  .Without(c => c.Address)
                  .Without(c => c.Orders)
                  .Create();
        }
    }
}
