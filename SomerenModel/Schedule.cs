using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SomerenModel
{
    public class Schedule
    {
        public int Id { get; set; }

        public string ActivitySupervisorName { get; set; }
        public string ActivityDescription { get; set; }

        public DateTime Datestart { get; set; }
        public DateTime Dateend { get; set; }
        public int Students { get; set; }

    }
}
