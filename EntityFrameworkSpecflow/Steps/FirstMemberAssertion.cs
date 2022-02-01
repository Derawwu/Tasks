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
    public sealed class FirstMemberAssertion
    {
        private IObjectContainer container;
        private FirstMemberAssertion(IObjectContainer _container)
        {
            this.container = _container;
            context = container.Resolve<NorthwindContext>("context");
        }

        IList<Customers> result;
        private SeedHelper helper = new();
        private NorthwindContext context;


        [When(@"the system perform get customer querry")]
        public void WhenTheSystemPerformGetCustomerQuerry()
        {
            helper.Seed(context);

            var querry = new GetCustomerQuerry(context);

            result = querry.Execute();
        }


        [Then(@"first member must be ""(.*)""")]
        public void ThenFirstMemberMustBe(string expectedResult)
        {
            result.First().CompanyName.Should().Be(expectedResult);
        }

    }
}
