using BoDi;
using EntittyFrameworkCoreTests.Helpers;
using EntityFrameworkSpecflow.Helpers;
using EntityFrameworkSpecflow.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace EntityFrameworkSpecflow.Steps
{
    [Binding]
    public sealed class CountOfCustomersInList
    {
        private IObjectContainer container;
        private CountOfCustomersInList(IObjectContainer _container)
        {
            this.container = _container;
            context = container.Resolve<NorthwindContext>("context");
        }

        IList<Customers> result;

        private SeedHelper helper = new();

        private NorthwindContext context;

        [When(@"system perform get customer querry")]
        public void WhenSystemPerformGetCustomerQuerry()
        {

            helper.Seed(context);

            var querry = new GetCustomerQuerry(context);

            result = querry.Execute();
        }

        [Then(@"count of customers must be equal to (.*)")]
        public void ThenCountOfCustomersMustBeEqualTo(int resultCount)
        {
            result.Count.Should().Be(resultCount);
        }

    }
}
