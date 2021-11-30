namespace ProcessScheduling.Scheduler.Policies
{
    using System;
    using System.Collections.Generic;
    using ProcessScheduling.Scheduler.Model;

    public class FirstComeFirstServePolicy : IPolicy
    {
        private readonly ProcessSchedulerConfig config;

        public FirstComeFirstServePolicy(ProcessSchedulerConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public bool UpdateProcessState(IEnumerable<ProcessEntryState> pResults)
        {
            var runningProcess = pResults.FirstOrDefault(p => p.ProcessState == ProcessStateEnum.Running);
            if (runningProcess is not null)
            {
                this.CheckRunningToLock(runningProcess);
            }

            bool skipUpdate = pResults.Any(p => p.ProcessState == ProcessStateEnum.Running);
            if (skipUpdate)
            {
                return true;
            }

            // Ninguno esta corriendo. Debo

            return false;
        }

        private void CheckRunningToLock(ProcessEntryState runningProcess)
        {
            
        }
    }
}
