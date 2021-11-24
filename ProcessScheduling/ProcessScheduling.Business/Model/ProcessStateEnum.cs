using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public enum ProcessStateEnum
    {
        New,
        Ready,
        Running,
        Locked,
        Complete,
    }
}
