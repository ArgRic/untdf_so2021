namespace ProcessScheduling.Scheduler.Policies
{
    using System;
    using System.Collections.Generic;
    using ProcessScheduling.Scheduler.Model;

    public class FirstComeFirstServePolicy : IPolicy
    {
        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries)
        {
            throw new NotImplementedException();
        }
    }
}
