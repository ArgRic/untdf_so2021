using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.Model
{
    public class ProcessEntryResult
    {
        public int ReturnTime { get; set; }
        public int ReturnTimeNormal { get; set; }
        public int ReadyTime { get; set; }
    }
}
