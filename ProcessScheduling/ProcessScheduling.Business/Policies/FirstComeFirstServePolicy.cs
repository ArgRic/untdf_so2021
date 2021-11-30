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

        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries)
        {
            return false;
        }
    }
}
