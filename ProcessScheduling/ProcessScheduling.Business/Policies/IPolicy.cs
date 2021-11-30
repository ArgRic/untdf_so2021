namespace ProcessScheduling.Scheduler.Policies
{
    using System.Collections.Generic;
    using ProcessScheduling.Scheduler.Model;

    public interface IPolicy
    {
        public bool UpdateProcessState(IEnumerable<ProcessEntryState> pResults);
    }
}
