using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public class ProcessEntryState
    {
        public ProcessEntry ProcessEntry { get; set; }
        public ProcessStateEnum ProcessState { get; set; }
        public int StateTime { get; set; }
        public int ServiceTime { get; set; }
        public float ServiceTimeRatio { get; set; }
        public int WaitTime { get; set; }
        public int ReadyTime { get; set; }
        public int LockTime { get; set; }
        public float ReturnTimeNormal { get; set; }
        public int ReturnTime { get; set; }

        public ProcessEntryState()
        {
            ProcessEntry = new ProcessEntry();
            this.ProcessState = ProcessStateEnum.New;
        }

        public bool Complete()
        {
            if (this.ProcessState == ProcessStateEnum.Running || this.ProcessState == ProcessStateEnum.Locked)
            {
                this.ProcessState = ProcessStateEnum.Complete;
                this.StateTime = 0;
                return true;
            }

            return false;

        }

        public bool Lock()
        {
            if (this.ProcessState == ProcessStateEnum.Running)
            {
                this.ProcessState = ProcessStateEnum.Locked;
                this.StateTime = 0;
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
                this.StateTime = 0;
                return true;
            }

            return false;
        }
        public bool Dispatch()
        {
            if (this.ProcessState == ProcessStateEnum.Ready)
            {
                this.ProcessState = ProcessStateEnum.Running;
                this.StateTime = 0;
                return true;
            }

            return false;
        }
    }
}
