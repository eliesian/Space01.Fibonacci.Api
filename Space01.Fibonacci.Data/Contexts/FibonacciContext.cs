using Space01.Fibonacci.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Space01.Fibonacci.Data.Contexts
{
    public class FibonacciDbContext : DbContext
    {
        public FibonacciDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<SequenceNumber> SequenceNumbers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SequenceNumber>().ToTable("SequenceNumber");
        }
    }
}
