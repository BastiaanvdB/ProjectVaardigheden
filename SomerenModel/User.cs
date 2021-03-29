using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class User
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String License { get; set; }
        public bool AdminStatus { get; set; }
    }
}
