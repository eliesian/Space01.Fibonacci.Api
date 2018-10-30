using Space01.Fibonacci.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Space01.Fibonacci.Data.Contexts
{
    public class InMemoryContext : FibonacciDbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext>options) : base(options)
        {}
    }
}
