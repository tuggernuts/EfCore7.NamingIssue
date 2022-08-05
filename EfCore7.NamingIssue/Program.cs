using System;
using System.Linq;
using EfCore7.NamingIssue.Data;
using Microsoft.EntityFrameworkCore;

namespace EfCore7.NamingIssue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var factory = new SampleDbContextFactory();
            factory.CreateContext().Companies
                .Include(c => c.Country)
                .Include(c => c.Assets)
                .ThenInclude(a => a.Manufacturer)
                .First();



        }

    }
}
