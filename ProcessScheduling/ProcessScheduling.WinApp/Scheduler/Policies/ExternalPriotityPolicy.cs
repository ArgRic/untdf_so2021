using ProcessScheduling.WinApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.Scheduler.Policies
{
    public class ExternalPriotityPolicy : IPolicy
    {
        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries)
        {
            throw new NotImplementedException();
        }
    }
}
