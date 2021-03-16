using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } // StudentNumber, e.g. 474791

        public decimal Price { get; set; }
        public decimal VAT { get; set; }

        public bool Age { get; set; }

        public int Stock { get; set; }

        public int Restocklevel { get; set; }

    }
}
