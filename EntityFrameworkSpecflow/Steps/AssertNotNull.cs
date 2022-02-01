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
    public sealed class AssertNotNull
    {
        private IObjectContainer container;
        private AssertNotNull(IObjectContainer _container)
        {
            this.container = _container;
            context = container.Resolve<NorthwindContext>("context");
        }

        IList<Customers> result;

        private SeedHelper helper = new();

        private NorthwindContext context;

        [When(@"system perform get all customer querry")]
        public void WhenSystemPerformGetAllCustomerQuerry()
        {
            helper.Seed(context);

            var querry = new GetCustomerQuerry(context);

            result = querry.Execute();
        }

        [Then(@"responce must not be null")]
        public void ThenResponceMustNotBeNull()
        {
            result.Should().NotBeNull();
        }

    }
}
