using EntittyFrameworkCoreTests.Helpers;
using EntittyFrameworkCoreTests.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace EntittyFrameworkCoreTests
{
    public class Tests
    {
        Random rand = new Random();

        public DbContextOptions<NorthwindContext> dbContextOptions;

        public DbContextOptionsBuilder<NorthwindContext> dbContextOptionsBuilder;

        NorthwindContext _context;

        [SetUp]
        public void Setup()
        {
            dbContextOptions = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Northwind" + Convert.ToString(rand.NextDouble()))
            .Options;
        }

        [Test]
        public void Test1()
        {
            _context = new NorthwindContext(dbContextOptions);

             Seed(_context);

            var querry = new GetCustomerQuerry(_context);

            var result = querry.Execute();

            Assert.AreEqual(5, result.Count);
        }
        [Test]
        public void Test2()
        {
            _context = new NorthwindContext(dbContextOptions);

            Seed(_context);

            var querry = new GetCustomerQuerry(_context);

            var result = querry.Execute();

            Assert.AreEqual("Global Logic", result.First().CompanyName);
        }

        [Test]
        public void Test3()
        {
            _context = new NorthwindContext(dbContextOptions);

            Seed(_context);

            var querry = new GetCustomerQuerry(_context);

            var result = querry.Execute();

            Assert.AreEqual(result.Count, result.Distinct().Count());
        }

        [Test]
        public void Test4()
        {
            _context = new NorthwindContext(dbContextOptions);

            Seed(_context);

            var querry = new GetCustomerQuerry(_context);

            var result = querry.Execute();

            Assert.NotNull(result);
        }


        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        private void Seed(NorthwindContext context) 
        {

            var customers = new[]
            {
                new Customers {CustomerId = "N",CompanyName = "Nix" },
                new Customers {CustomerId = "P",CompanyName = "PX" },
                new Customers {CustomerId = "S",CompanyName = "SoftServe" },
                new Customers {CustomerId = "G",CompanyName = "Global Logic" },
                new Customers {CustomerId = "U",CompanyName = "Udemy" },
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        

    }
}