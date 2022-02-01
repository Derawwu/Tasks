using EntityFrameworkSpecflow.Models;
using System.Collections.Generic;
using System.Linq;

namespace EntittyFrameworkCoreTests.Helpers
{
    internal class GetCustomerQuerry
    {
        private readonly NorthwindContext _context;

        public GetCustomerQuerry(NorthwindContext context)
        {
            _context = context;
        }

        public IList<Customers> Execute()
        {
            return _context.Customers
                                    .OrderBy(c => c.CompanyName)
                                    .ToList();
        }
    }
}
