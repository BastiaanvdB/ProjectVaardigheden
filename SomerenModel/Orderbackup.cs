using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Order
    {
        public int OrderId { get; set; }
        public int VoucherId;
        public int ActivityId;
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
