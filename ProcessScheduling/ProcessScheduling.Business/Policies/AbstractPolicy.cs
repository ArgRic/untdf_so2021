using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Policies
{
    public abstract class AbstractPolicy : IPolicy
    {
        protected readonly ProcessSchedulerConfig config;

        protected AbstractPolicy(ProcessSchedulerConfig config) 
        { 
           this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public virtual bool UpdateProcessState(IList<ProcessEntryState> pResults)
        {
            throw new NotImplementedException();
        }

        public void CheckNewToReady(IList<ProcessEntryState> pResults, int overhead)
        {
            var newProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.New);
            foreach (var newP in newProcesses)
            {
                if (newP.StateTime >= overhead + newP.ProcessEntry.ArrivalTime)
                {
                    newP.Ready();
                }
            }
        }

        public void CheckRunningToLock(IList<ProcessEntryState> pResults)
        {
            var runningProcess = pResults.FirstOrDefault(p => p.ProcessState == ProcessStateEnum.Running);
            if (runningProcess is not null)
            {
                if (runningProcess.StateTime >= runningProcess.ProcessEntry.BurstTime)
                {
                    runningProcess.Lock();
                }
            }
        }

        public void CheckLockToReadyOrComplete(IList<ProcessEntryState> pResults)
        {
            var lockedProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.Locked).ToList();
            foreach (var lockedP in lockedProcesses)
            {
                if (lockedP.StateTime >= lockedP.ProcessEntry.IOBurstTime)
                {
                    // El proceso termino su tiempo de I/O.
                    int serviceTimeToComplete = lockedP.ProcessEntry.BurstTime * lockedP.ProcessEntry.BurstsQtyToComplete;
                    if (serviceTimeToComplete <= lockedP.ServiceTime)
                    {
                        // El proceso tambien termino su tiempo de CPU
                        lockedP.Complete();
                        continue;
                    }

                    lockedP.Ready();
                }
            }
        }
    }
}
