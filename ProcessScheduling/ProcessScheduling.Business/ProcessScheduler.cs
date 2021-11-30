

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

        public ProcessScheduler(PolicyEnum policy, IEnumerable<ProcessEntry> processEntries, ProcessSchedulerConfig config)
        {
            this.ProcessEntries = processEntries ?? throw new ArgumentNullException(nameof(processEntries));
            this.ProcessSchedulerConfig = config ?? throw new ArgumentNullException(nameof(config));
            this.ProcessSchedulerPolicy = this.PolicyFactory(policy) ?? throw new ArgumentNullException(nameof(policy));
        }

        public SchedulerResult Work()
        {
            int totalCpuTime = 0;
            int processCount = this.ProcessEntries.Count();
            var schedulerResult = new SchedulerResult { ResultMessage = "Sin resultados" };
            IEnumerable<ProcessEntryState> processes = this.ProcessEntries.Select(p => new ProcessEntryState { ProcessEntry = p });

            while (!this.WorkIsDone(processes))
            {
                // Nueva instancia evento
                totalCpuTime++;
                var currentEvent = new SchedulerEvent();
                
                // Actualizo estado de los procesos para la instancia segun politica.
                bool success = this.ProcessSchedulerPolicy.UpdateProcessState(processes);
                if (!success)
                    throw new Exception("Error en " + nameof(ProcessSchedulerPolicy.UpdateProcessState));

                // Actualizo Output segun nuevo estado de procesos.
                foreach (var pState in processes)
                {
                    currentEvent.ProcessSnapshots.Add(new ProcessSnapshot {
                        ProcessEntryId = pState.ProcessEntry.Id,
                        ProcessEntryName = pState.ProcessEntry.Name,
                        ProcessEntryState = pState.ProcessState
                    });

                    this.UpdateEntryResultByProcessEntryState(
                        pState,
                        pState.ProcessState, 
                        this.ProcessEntries.Count(), 
                        totalCpuTime);
                }

                schedulerResult.SchedulerEvents.Add(currentEvent);
            }

            if (processCount > 0)
                this.UpdateSchedulerResult(schedulerResult);
            return schedulerResult;
        }

        private bool WorkIsDone(IEnumerable<ProcessEntryState> entries)
        {
            if (!entries.Any())
                return true;

            return entries.All(p => p.ProcessState == ProcessStateEnum.Complete);
        }

        private void UpdateEntryResultByProcessEntryState(ProcessEntryState pResult, ProcessStateEnum pState, int processQuantity, int eventCount)
        {
            pResult.StateTime++;
            if (pState != ProcessStateEnum.Complete) 
            { 
                // Actualizo Acumuladores
                pResult.ReturnTime++;
                switch (pState)
                {
                    case ProcessStateEnum.Running: pResult.ServiceTime++; break;
                    case ProcessStateEnum.Ready: pResult.ReadyTime++; break;
                    case ProcessStateEnum.Locked: pResult.LockTime++; break;
                    case ProcessStateEnum.New: pResult.WaitTime++; break;
                    default: break;
                }
                // Actualizo estado calculado.
                pResult.ReturnTimeNormal = pResult.ReturnTime / processQuantity; // Dividido cpuTime
            }
            pResult.ServiceTimeRatio = eventCount / pResult.ServiceTime;
        }

        private void UpdateSchedulerResult(SchedulerResult schedulerResult)
        {
            var resultQuantity = schedulerResult.EntryResults.Count();
            schedulerResult.ReturnTime = schedulerResult.EntryResults.Select(er => er.ReturnTime).Aggregate((a, b) => a + b);
            schedulerResult.ReturnTimeMedia = schedulerResult.EntryResults.Select(er => er.ReturnTime).Aggregate((a, b) => a + b) / resultQuantity;
            schedulerResult.ReadyTime = schedulerResult.EntryResults.Select(er => er.ReadyTime).Aggregate((a, b) => a + b);
            schedulerResult.CpuIdleTime = schedulerResult.EntryResults.Select(er => er.WaitTime).Aggregate((a, b) => a + b);
            schedulerResult.CpuOperatingSystemUseTime = schedulerResult.EntryResults.Select(er => er.LockTime).Aggregate((a, b) => a + b);
            schedulerResult.CpuProcessUseTime = schedulerResult.EntryResults.Select(er => er.ServiceTime).Aggregate((a, b) => a + b);
            schedulerResult.ResultMessage = $"Terminado";
        }

        private IPolicy PolicyFactory(PolicyEnum policyEnum)
        {
            return policyEnum switch
            {
                PolicyEnum.ShortestProcessNext => new ShortestProcessNextPolicy(this.ProcessSchedulerConfig),
                PolicyEnum.FirstComeFirstServe => new FirstComeFirstServePolicy(this.ProcessSchedulerConfig),
                PolicyEnum.ExternalPriotity => new ExternalPriotityPolicy(this.ProcessSchedulerConfig),
                PolicyEnum.RoundRobin => new RoundRobinPolicy(this.ProcessSchedulerConfig),
                PolicyEnum.ShortestRemainingTime => new ShortestRemainingTimePolicy(this.ProcessSchedulerConfig),
                _ => new FirstComeFirstServePolicy(this.ProcessSchedulerConfig),
            };
        }
    }
}
