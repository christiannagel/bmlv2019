using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDBSampleWithEFCore
{
    public class MyRunner
    {
        private PeopleContext _context;
        public MyRunner(PeopleContext context)
        {
            _context = context;
        }

        public Task CreateTheDatabaseAsync()
        {
            return _context.Database.EnsureCreatedAsync();
        }

        public async Task AddPersonAsync(Person p)
        {
            _context.People.Add(p);
            int changed = await _context.SaveChangesAsync();
            Console.WriteLine($"changed {changed} records");
        }
    }
}
