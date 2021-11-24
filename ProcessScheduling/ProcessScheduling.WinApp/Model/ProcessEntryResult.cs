using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.Model
{
    public class ProcessEntryResult
    {
        public int ProcessEntryId { get; set; }
        public string ProcessEntryName { get; set; }
        public int CpuTime { get; set; }
        public float CpuTimeRatio { get; set; }
        public int WaitTime { get; set; }
        public int ReadyTime { get; set; }
        public int LockTime { get; set; }
        public float ReturnTimeNormal { get; set; }
        public int ReturnTime { get; set; }

        public ProcessEntryResult()
        {
            ProcessEntryName = string.Empty;
        }
    }
}
