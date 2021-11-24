

namespace ProcessScheduling.Scheduler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ProcessScheduling.Scheduler.Model;
    using ProcessScheduling.Scheduler.Policies;

    public class ProcessScheduler
    {
        private readonly IEnumerable<ProcessEntry> ProcessEntries;
        private readonly ProcessSchedulerConfig ProcessSchedulerConfig;
        private readonly IPolicy ProcessSchedulerPolicy;

        public ProcessScheduler(IPolicy policy, IEnumerable<ProcessEntry> processEntries, ProcessSchedulerConfig config)
        {
            this.ProcessEntries = processEntries ?? throw new ArgumentNullException(nameof(processEntries));
            this.ProcessSchedulerConfig = config ?? throw new ArgumentNullException(nameof(config));
            this.ProcessSchedulerPolicy = policy ?? throw new ArgumentNullException(nameof(policy));
        }

        public SchedulerResult Work()
        {
            int totalCpuTime = 0;
            int processCount = this.ProcessEntries.Count();
            var schedulerResult = new SchedulerResult
            {
                EntryResults = this.ProcessEntries.Select(p => new ProcessEntryResult { ProcessEntryId = p.Id }),
                ResultMessage = "Sin resultados",
            };

            while (!this.WorkIsDone(this.ProcessEntries))
            {
                // Nueva instancia evento
                totalCpuTime++;
                var currentEvent = new SchedulerEvent();
                
                // Actualizo estado de los procesos para la instancia segun politica.
                bool success = this.ProcessSchedulerPolicy.UpdateProcessEntries(ProcessEntries);
                if (!success)
                    throw new Exception("Error en " + nameof(ProcessSchedulerPolicy.UpdateProcessEntries));

                // Actualizo Output segun nuevo estado de procesos.
                foreach (var entry in this.ProcessEntries)
                {
                    currentEvent.ProcessSnapshots.Add(new ProcessSnapshot {
                        ProcessEntryId = entry.Id,
                        ProcessEntryName = entry.Name,
                        ProcessEntryState = entry.ProcessState
                    });

                    var entryResult = schedulerResult.EntryResults.First(r => r.ProcessEntryId == entry.Id);
                    this.UpdateEntryResultByProcessEntryState(
                        entryResult, 
                        entry.ProcessState, 
                        this.ProcessEntries.Count(), 
                        totalCpuTime);
                }

                schedulerResult.SchedulerEvents.Add(currentEvent);
            }

            if (processCount > 0)
                this.UpdateSchedulerResult(schedulerResult);
            return schedulerResult;
        }

        private bool WorkIsDone(IEnumerable<ProcessEntry> entries)
        {
            if (!entries.Any())
                return true;

            return entries.All(p => p.ProcessState == ProcessStateEnum.Complete);
        }

        private void UpdateEntryResultByProcessEntryState(ProcessEntryResult pResult, ProcessStateEnum pState, int processQuantity, int eventCount)
        {
            if (pState != ProcessStateEnum.Complete) 
            { 
                // Actualizo Acumuladores
                pResult.ReturnTime++;
                switch (pState)
                {
                    case ProcessStateEnum.Running: pResult.CpuTime++; break;
                    case ProcessStateEnum.Ready: pResult.ReadyTime++; break;
                    case ProcessStateEnum.Locked: pResult.LockTime++; break;
                    case ProcessStateEnum.New: pResult.WaitTime++; break;
                    default: break;
                }
            }

            // Actualizo estado calculado.
            pResult.ReturnTimeNormal = pResult.ReadyTime / processQuantity;
            pResult.CpuTimeRatio = eventCount / pResult.CpuTime;
        }

        private void UpdateSchedulerResult(SchedulerResult schedulerResult)
        {
            var resultQuantity = schedulerResult.EntryResults.Count();
            schedulerResult.ReturnTime = schedulerResult.EntryResults.Select(er => er.ReturnTime).Aggregate((a, b) => a + b);
            schedulerResult.NormalizedReturnTime = schedulerResult.EntryResults.Select(er => er.ReturnTime).Aggregate((a, b) => a + b) / resultQuantity;
            schedulerResult.ReadyTime = schedulerResult.EntryResults.Select(er => er.ReadyTime).Aggregate((a, b) => a + b);
            schedulerResult.CpuIdleTime = schedulerResult.EntryResults.Select(er => er.WaitTime).Aggregate((a, b) => a + b);
            schedulerResult.CpuOperatingSystemUseTime = schedulerResult.EntryResults.Select(er => er.LockTime).Aggregate((a, b) => a + b);
            schedulerResult.CpuProcessUseTime = schedulerResult.EntryResults.Select(er => er.CpuTime).Aggregate((a, b) => a + b);
            schedulerResult.ResultMessage = $"Terminado";
        }
    }
}
