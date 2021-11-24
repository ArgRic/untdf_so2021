namespace ProcessScheduling.WinApp.Scheduler.Policies
{
    using ProcessScheduling.WinApp.Model;

    public interface IPolicy
    {
        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries);
    }
}
