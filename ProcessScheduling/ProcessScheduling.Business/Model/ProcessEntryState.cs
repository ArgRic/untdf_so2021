using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public class ProcessEntryState
    {
        public ProcessEntry ProcessEntry { get; set; }
        public int ServiceTime { get; set; }
        public float ServiceTimeRatio { get; set; }
        public int WaitTime { get; set; }
        public int ReadyTime { get; set; }
        public int LockTime { get; set; }
        public float ReturnTimeNormal { get; set; }
        public int ReturnTime { get; set; }

        public ProcessEntryState()
        {
            ProcessEntry = new ProcessEntry();
        }
    }
}
