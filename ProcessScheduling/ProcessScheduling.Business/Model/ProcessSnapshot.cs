namespace ProcessScheduling.Scheduler.Model
{
    public class ProcessSnapshot
    {
        public int ProcessEntryId { get; set; }
        public string ProcessEntryName { get; set; }
        public ProcessStateEnum ProcessEntryState { get; set; }

        public ProcessSnapshot()
        {
            this.ProcessEntryName = string.Empty;
        }

        public override string ToString()
        {
            switch (ProcessEntryState)
            {
                case ProcessStateEnum.Running: return "S";
                case ProcessStateEnum.New: return "·";
                case ProcessStateEnum.Ready: return "R";
                case ProcessStateEnum.Locked: return "IO";
                case ProcessStateEnum.Exit: return "E";
                case ProcessStateEnum.Terminated: return "T";
                default : return string.Empty;
            }
        }
    }
}