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
        public bool UpdateProcessEntries(IEnumerable<ProcessEntry> processEntries)
        {
            throw new NotImplementedException();
        }
    }
}
