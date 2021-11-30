﻿using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Policies
{
    public class RoundRobinPolicy : IPolicy
    {
        private readonly ProcessSchedulerConfig config;

        public RoundRobinPolicy(ProcessSchedulerConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries)
        {
            throw new NotImplementedException();
        }
    }
}
