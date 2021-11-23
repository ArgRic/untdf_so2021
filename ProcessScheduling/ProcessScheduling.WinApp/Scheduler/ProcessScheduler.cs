namespace ProcessScheduling.WinApp.Scheduler
{
    using ProcessScheduling.WinApp.Model;
    using ProcessScheduling.WinApp.Scheduler.Policies;

    public class ProcessScheduler
    {
        private IEnumerable<ProcessEntry> ProcessEntries;
        private ProcessSchedulerConfig ProcessSchedulerConfig;
        private IPolicy ProcessSchedulerPolicy;

        public ProcessScheduler(IPolicy policy, IEnumerable<ProcessEntry> processEntries, ProcessSchedulerConfig config)
        {
            this.ProcessEntries = processEntries ?? throw new ArgumentNullException(nameof(processEntries));
            this.ProcessSchedulerConfig = config ?? throw new ArgumentNullException(nameof(config));
            this.ProcessSchedulerPolicy = policy ?? throw new ArgumentNullException(nameof(policy));

        }

        public SchedulerResult Work()
        {
            var result = new SchedulerResult { 
                EntryResults = new List<ProcessEntryResult>(),

            };

            

            return result;
        }


    }
}
