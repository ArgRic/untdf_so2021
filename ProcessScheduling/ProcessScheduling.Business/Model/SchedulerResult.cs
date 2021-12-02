using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Model
{
    public class SchedulerResult
    {
        public ProcessSchedulerConfig Config { get; set; }
        public int ReturnTime { get; set; }
        public float ReturnTimeMedia { get; set; }
        public int ReadyTime { get; set; }
        public int CpuIdleTime { get; set; }
        public int CpuOperatingSystemUseTime { get; set; }
        public int CpuProcessUseTime { get; set; }
        public IEnumerable<ProcessEntryState> Processes { get; set; }
        public IList<SchedulerEvent> SchedulerEvents { get; set; }
        public string ResultMessage { get; set; }

        public SchedulerResult()
        {
            this.Config = new ProcessSchedulerConfig();
            this.Processes = new List<ProcessEntryState>();
            this.SchedulerEvents = new List<SchedulerEvent>();
            this.ResultMessage = string.Empty;
        }

        public string[] GetResultReportLinesArray()
        {
            List<string> lines = new List<string>
            {
                $"Politica: {Config.Policy}",
                $"TIP: {Config.OverheadTimeToAccept} TFP: {Config.OverheadTimeToComplete}",
                $"TCP: {Config.OverheadTimeToExchange} Quatum: {Config.Quantum}",
                string.Empty,
                $"# Input Procesos"
            };

            var entries = this.Processes.Select(p => p.ProcessEntry);
            int i = 0;
            foreach (var p in entries)
            {
                string processInput = $"{++i}. {p.Name}, tArribo {p.ArrivalTime}, RafagaCPU: {p.BurstTime} (x {p.BurstsQtyToComplete}), RafagaIO: {p.IOBurstTime}, Prioridad {p.Priority}";
                lines.Add(processInput);
            }

            lines.Add(string.Empty);
            lines.Add("# Output Tanda");
            lines.Add($"tRetornoTanda {ReturnTime}  tMedioRetornoTanda {ReturnTimeMedia}");


            i = 0;
            lines.Add("# Output x Procesos");
            foreach (var p in this.Processes)
            {
                List<string> processOutput = new List<string>
                {
                    $"{++i}. {p.ProcessEntry.Name}", 
                    $"{p.ProcessEntry.Name}>> tRetornoTotal: {p.ProcessReturnTime}, tRetornoNormalizado {p.ProcessNormalizedReturnTime:0.00}",
                    $"{p.ProcessEntry.Name}>> tCPU {p.ServiceTime} ({(p.ServiceTimeRatio*100):0.##\\%}), tEspera {p.WaitTime}, tEntradaSalida {p.LockTime}",
                    String.Empty,
                };
                lines.AddRange(processOutput);
            }

            lines.Add("# Fin Informe");

            return lines.ToArray();
        }
    }
}
