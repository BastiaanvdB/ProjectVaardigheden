using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    class Activity
    {
        public int ActivityId { get; set; }
        public int StudentId;
        public int MentorId;
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
    }
}
