using BoDi;
using EntittyFrameworkCoreTests.Helpers;
using EntityFrameworkSpecflow.Helpers;
using EntityFrameworkSpecflow.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace EntityFrameworkSpecflow.Steps
{
    [Binding]
    public sealed class EqualityOfAllAndDistinctCustomers
    {
        private IObjectContainer container;
        private EqualityOfAllAndDistinctCustomers(IObjectContainer _container)
        {
            this.container = _container;
            context = container.Resolve<NorthwindContext>("context");
        }

        IList<Customers> result;

        private SeedHelper helper = new();

        private NorthwindContext context;

        [When(@"the system perform get all customer querry")]
        public void WhenTheSystemPerformGetAllCustomerQuerry()
        {
            helper.Seed(context);

            var querry = new GetCustomerQuerry(context);

            result = querry.Execute();
        }


        [Then(@"count of all customers must be equal to the count of distinct users")]
        public void ThenCountOfAllCustomersMustBeEqualToTheCountOfDistinctUsers()
        {
            result.Count.Should().Be(result.Distinct().Count());
        }

    }
}
