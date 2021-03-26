using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class ActivitySupervisor
    {
        public int SupervisorId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string TeacherName { get; set; }
        public int TeacherId { get; set; }

    }
}
