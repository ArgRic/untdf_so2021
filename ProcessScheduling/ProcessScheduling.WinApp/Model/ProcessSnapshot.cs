namespace ProcessScheduling.WinApp.Model
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
                case ProcessStateEnum.Running: return "R";
                case ProcessStateEnum.New: return "·";
                case ProcessStateEnum.Ready: return "W";
                case ProcessStateEnum.Locked: return "L";
                case ProcessStateEnum.Complete: return "C";
                default : return string.Empty;
            }
        }
    }
}