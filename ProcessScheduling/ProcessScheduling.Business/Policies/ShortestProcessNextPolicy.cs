using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Policies
{
    public class ShortestProcessNextPolicy : IPolicy
    {
        private readonly ProcessSchedulerConfig config;

        public ShortestProcessNextPolicy(ProcessSchedulerConfig config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public bool UpdateProcessState(IEnumerable<ProcessEntryState> pResults)
        {
            throw new NotImplementedException();
        }
    }
}
