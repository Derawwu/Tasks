using BoDi;
using EntityFrameworkSpecflow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace EntityFrameworkSpecflow.Hooks
{
    [Binding]
    public sealed class Hook
    {
        Random rand = new Random();

        private IObjectContainer container;

        public DbContextOptions<NorthwindContext> dbContextOptions;

        private  NorthwindContext context;
        public Hook(ObjectContainer _container)
        {
            this.container = _container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            dbContextOptions = new DbContextOptionsBuilder<NorthwindContext>()
            .UseInMemoryDatabase(databaseName: "Northwind" + Convert.ToString(rand.NextDouble()))
            .Options;
            context = new NorthwindContext(dbContextOptions);
            container.RegisterInstanceAs(context, "context");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            context.Dispose();
        }
    }
}
