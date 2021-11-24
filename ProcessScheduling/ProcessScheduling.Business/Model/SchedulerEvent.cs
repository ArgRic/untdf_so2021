using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public class SchedulerEvent
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Message { get; set; }
        public IList<ProcessSnapshot> ProcessSnapshots { get; set; }

        public SchedulerEvent()
        {
            this.Id = IdCounter++;
            this.Message = string.Empty;
            this.ProcessSnapshots = new List<ProcessSnapshot>();
        }

    }
}
