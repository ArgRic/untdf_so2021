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
        public int CpuBurstsToComplete { get; set; }
        public int CpuBurstDuration { get; set; }
        public int IOBurstDuration { get; set; }
        public int Priority { get; set; }
        public ProcessStateEnum ProcessState { get; set; }

        public ProcessEntry()
        {
            this.Id = IdCounter++;
            this.Name = String.Empty;
            this.ProcessState = ProcessStateEnum.New;
        }

        public bool Complete()
        {
            if (this.ProcessState == ProcessStateEnum.Running)
            {
                this.ProcessState = ProcessStateEnum.Complete;
                return true;
            }

            return false;

        }

        public bool Lock()
        {
            if (this.ProcessState == ProcessStateEnum.Running)
            {
                this.ProcessState = ProcessStateEnum.Locked;
                return true;
            }

            return false;

        }

        public bool Ready()
        {
            if (this.ProcessState == ProcessStateEnum.Locked ||
                this.ProcessState == ProcessStateEnum.Running ||
                this.ProcessState == ProcessStateEnum.New)
            {
                this.ProcessState = ProcessStateEnum.Ready;
                return true;
            }

            return false;
        }
        public bool Dispatch()
        {
            if (this.ProcessState == ProcessStateEnum.Ready)
            {
                this.ProcessState = ProcessStateEnum.Running;
                return true;
            }

            return false;
        }

    }
}
