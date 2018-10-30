using Space01.Fibonacci.Data.Models;
using Space01.Fibonacci.Data.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Space01.Fibonacci.Data.Initializers
{
    public static class FibonacciSequenceGenerator
    {
        public static void Initialize(FibonacciDbContext context, int maxNumber)
        {
            context.Database.EnsureCreated();

            if (context.SequenceNumbers.Any()) { return; }
            context.SequenceNumbers.AddRange(GenerateFibonacciSequence(maxNumber));
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.SequenceNumber ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.SequenceNumber OFF");
                transaction.Commit();
            }
        }
        private static SequenceNumber[] GenerateFibonacciSequence(int maxNumber) {
            var numbers = new List<SequenceNumber>();
            BigInteger a = 0, b = 1, c=0;
            numbers.Add(new SequenceNumber() { Sequence = 1, Number = a.ToString() });
            numbers.Add(new SequenceNumber() { Sequence = 2, Number = b.ToString() });
            for (int i = 2; i < maxNumber; i++)
            {
                c = a + b;
                numbers.Add(new SequenceNumber() { Sequence = i + 1, Number = c.ToString() });
                a = b;
                b = c;
            }
            return numbers.ToArray<SequenceNumber>();
        }
    }
}
