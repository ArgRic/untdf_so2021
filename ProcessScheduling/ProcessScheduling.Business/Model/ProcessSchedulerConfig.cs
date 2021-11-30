namespace ProcessScheduling.Scheduler
{
    using ProcessScheduling.Scheduler.Model;

    public class ProcessSchedulerConfig
    {
        public int OverheadTimeToAccept { get; set; }
        public int OverheadTimeToComplete { get; set; }
        public int OverheadTimeToExchange { get; set; }
        public int Quantum { get; set; }
        public PolicyEnum Policy { get; set; }

    }
}
