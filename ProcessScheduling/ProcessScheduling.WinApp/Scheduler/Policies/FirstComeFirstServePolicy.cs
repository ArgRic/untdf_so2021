﻿namespace ProcessScheduling.WinApp.Scheduler.Policies
{
    using System;
    using System.Collections.Generic;
    using ProcessScheduling.WinApp.Model;

    public class FirstComeFirstServePolicy : IPolicy
    {
        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries)
        {
            throw new NotImplementedException();
        }
    }
}
