﻿namespace ProcessScheduling.WinApp.Scheduler
{
    using ProcessScheduling.WinApp.Model;

    public class ProcessSchedulerConfig
    {
        public int Tip { get; set; }
        public int Tfp { get; set; }
        public int Tcp { get; set; }
        public int Quantum { get; set; }
        public PolicyEnum Policy { get; set; }

    }
}
