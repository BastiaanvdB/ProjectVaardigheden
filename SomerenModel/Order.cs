using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderDetailsId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int VoucherId { get; set; }
        public DateTime Date { get; set; }
        public bool PayStatus { get; set; }
    }
}
