namespace ProcessScheduling.WinApp.Scheduler.Policies
{
    using System.Collections.Generic;
    using ProcessScheduling.WinApp.Model;

    public interface IPolicy
    {
        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries);
    }
}
