using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.Model
{
    public class ProcessEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int CpuBurstsToComplete { get; set; }
        public int CpuBurstDuration { get; set; }
        public int IOBurstDuration { get; set; }
        public int Priority { get; set; }

    }
}
