using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public enum PolicyEnum
    {
        FirstComeFirstServe,
        ExternalPriority,
        RoundRobin,
        ShortestProcessNext,
        ShortestRemainingTime,
    }
}
