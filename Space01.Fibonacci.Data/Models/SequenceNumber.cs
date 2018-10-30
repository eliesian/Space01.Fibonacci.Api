using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Space01.Fibonacci.Data.Models
{
    public class SequenceNumber
    {
        [Key]
        public int Sequence { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Number { get; set; }
    }
}
