namespace ProcessScheduling.WinApp.Model
{
    public class ProcessSnapshot
    {
        public int ProcessEntryId { get; set; }
        public ProcessStateEnum ProcessEntryState { get; set; }

        public ProcessSnapshot()
        {
            ProcessEntryName = string.Empty;
        }
    }
}