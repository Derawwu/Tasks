using EntityFrameworkSpecflow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkSpecflow.Helpers
{
    class SeedHelper
    {
        public SeedHelper()
        {

        }

        public void Seed(NorthwindContext context)
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
