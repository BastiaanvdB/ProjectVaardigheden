using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class AdminRequest
    {
        public int AdminRequestId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
}
