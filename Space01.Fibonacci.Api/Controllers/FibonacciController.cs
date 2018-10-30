using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Space01.Fibonacci.Data.Models;
using Space01.Fibonacci.Data.Contexts;

namespace Space01.Fibonacci.Api.Controllers
{
    [Route("api/[controller]")]
    public class FibonacciController : ControllerBase
    {
        private readonly FibonacciDbContext _context;
        public FibonacciController(FibonacciDbContext context)
        {
            this._context = context;
        }
        [HttpGet("{first}/{last}")]
        public BigInteger[] Get(int first, int last)
        {
            if (first > 0)
                first--;
            return _context.SequenceNumbers.OrderBy(n => n.Sequence).Skip(first).Take(last - first).ToList<SequenceNumber>().Select(e => BigInteger.Parse(e.Number,System.Globalization.NumberStyles.Integer)).ToArray<BigInteger>();
        }
    }
}
