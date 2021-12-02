using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public class ProcessEntry
    {
        private static int IdCounter = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstsQtyToComplete { get; set; }
        public int BurstTime { get; set; }
        public int IOBurstTime { get; set; }
        public int Priority { get; set; }
        public int ServiceTimeToComplete { get => BurstTime * BurstsQtyToComplete; }
        public int LockTimeToComplete { get => (IOBurstTime * (this.BurstsQtyToComplete - 1)) + IOBurstTime; }

        public ProcessEntry()
        {
            this.Id = IdCounter++;
            this.Name = String.Empty;
        }

    }
}
