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
        protected int CurrentExchangeTime;

        protected AbstractPolicy(ProcessSchedulerConfig config)
        {
            CurrentExchangeTime = 0;
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public virtual bool UpdateProcessState(IList<ProcessEntryState> pResults)
        {
            throw new NotImplementedException();
        }

        public void CommonChecks(IList<ProcessEntryState> processes)
        {
            CheckNewToReady(processes, config.OverheadTimeToAccept);
            CheckRunningToLockOrExit(processes);
            CheckExitToComplete(processes, config.OverheadTimeToComplete);
            CheckLockToReady(processes);
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

        public void CheckRunningToLockOrExit(IList<ProcessEntryState> pResults)
        {
            var runningProcess = pResults.FirstOrDefault(p => p.ProcessState == ProcessStateEnum.Running);
            if (runningProcess is not null)
            {
                if (runningProcess.ServiceTime >= runningProcess.ProcessEntry.ServiceTimeToComplete)
                {
                    //Fue la ultima rafaga CPU. 
                    if (runningProcess.LockTime < runningProcess.ProcessEntry.LockTimeToComplete)
                    {
                        // Tiene pendiente entrada/salida.
                        runningProcess.Lock();
                        return;
                    }

                    runningProcess.Exit();
                    return;
                }

                if (runningProcess.StateTime >= runningProcess.ProcessEntry.BurstTime)
                {
                    // Termino el uso de CPU actual.
                    if (runningProcess.LockTime < runningProcess.ProcessEntry.LockTimeToComplete)
                    {
                        // Tiene pendiente entrada/salida.
                        runningProcess.Lock();
                        return;
                    }
                }
            }
        }

        public void CheckExitToComplete(IList<ProcessEntryState> pResults, int exitOverhead)
        {
            var exitProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.Exit).ToList();
            foreach (var lockedP in exitProcesses)
            {
                if (lockedP.StateTime >= exitOverhead)
                {
                    lockedP.Terminate();
                }
            }
        }

        public void CheckLockToReady(IList<ProcessEntryState> pResults)
        {
            var lockedProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.Locked).ToList();
            foreach (var lockedP in lockedProcesses)
            {
                if (lockedP.StateTime >= lockedP.ProcessEntry.IOBurstTime)
                {
                    lockedP.Ready();
                }
            }
        }
    }
}
