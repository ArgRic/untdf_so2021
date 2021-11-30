﻿namespace ProcessScheduling.Scheduler.Policies
{
    using System;
    using System.Collections.Generic;
    using ProcessScheduling.Scheduler.Model;

    public class ExternalPriotityPolicy : IPolicy
    {
        private readonly ProcessSchedulerConfig config;

        public ExternalPriotityPolicy(ProcessSchedulerConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public bool UpdateProcessState(IList<ProcessEntryState> pResults)
        {
            throw new NotImplementedException();
        }
    }
}
