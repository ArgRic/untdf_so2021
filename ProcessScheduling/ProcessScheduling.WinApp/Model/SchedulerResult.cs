using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.Model
{
    public class SchedulerResult
    {
        public int ReturnTime { get; set; }
        public int NormalizedReturnTime { get; set; }
        public int ReadyTime { get; set; }
        public int CpuIdleTime { get; set; }
        public int CpuOperatingSystemUseTime { get; set; }
        public int CpuProcessUseTime { get; set; }
        public IEnumerable<ProcessEntryResult> EntryResults { get; set; }
        public string ResultMessage { get; set; }
    }
}
