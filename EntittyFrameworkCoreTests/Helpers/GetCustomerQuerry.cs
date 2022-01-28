using EntittyFrameworkCoreTests.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
