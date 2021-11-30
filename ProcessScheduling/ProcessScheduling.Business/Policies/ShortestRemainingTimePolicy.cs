using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Policies
{
    public class ShortestRemainingTimePolicy : AbstractPolicy
    {
        private Dictionary<string, int> ProcessStateRecovery;

        public ShortestRemainingTimePolicy(ProcessSchedulerConfig config) : base(config)
        {
            ProcessStateRecovery = new Dictionary<string, int>();
        }

        public override bool UpdateProcessState(IList<ProcessEntryState> pResults)
        {
            // Arrivos y Salidas
            this.CheckNewToReady(pResults, config.OverheadTimeToAccept);
            this.CheckRunningToLock(pResults);
            this.CheckLockToReadyOrComplete(pResults, config.OverheadTimeToComplete);

            // Salgo si termino la tanda.
            if (pResults.All(p => p.ProcessState == ProcessStateEnum.Complete))
            {
                return true;
            }

            // ShortestRemainingTime es preemptiva. El proceso que aun corre puede interrumpirse
            if (pResults.Any(p => p.ProcessState == ProcessStateEnum.Running))
            {
                this.CheckRunningToReadyByRemainingTime(pResults);
            }

            // Si el proceso no fue interrumpido y sigue corriendo. Salgo
            if (pResults.Any(p => p.ProcessState == ProcessStateEnum.Running))
            {
                return true;
            }

            if (pResults.Any(p => p.ProcessState == ProcessStateEnum.Ready))
            {
                // Hay procesos en espera o corriendo. El Scheduler se encuentra conmutando. 
                CurrentExchangeTime++;
                if (CurrentExchangeTime >= config.OverheadTimeToExchange)
                {
                    CurrentExchangeTime = 0;
                    this.CheckReadyToRunning(pResults);
                }
            }

            return true;
        }

        private void CheckRunningToReadyByRemainingTime(IList<ProcessEntryState> pResults)
        {
            var runningProcess = pResults.FirstOrDefault(p => p.ProcessState == ProcessStateEnum.Running);
            if (runningProcess is not null)
            {
                var lowestServiceTimeProcess = pResults
                    .Where(p => p.ProcessState == ProcessStateEnum.Ready)
                    .MinBy(p => RemainingTime(p));
                if (lowestServiceTimeProcess is not null)
                {
                    // El proceso se interrumpe por existencia de otro listo con mayor prioridad.
                    if (this.ProcessStateRecovery.ContainsKey(runningProcess.ProcessEntry.Name))
                        this.ProcessStateRecovery[runningProcess.ProcessEntry.Name] = runningProcess.StateTime;
                    else
                        this.ProcessStateRecovery.Add(runningProcess.ProcessEntry.Name, runningProcess.StateTime);

                    runningProcess.Ready();
                }

            }
        }

        private int RemainingTime(ProcessEntryState p)
        {
            int totalServiceRequired = p.ProcessEntry.BurstTime * p.ProcessEntry.BurstsQtyToComplete;
            return totalServiceRequired - p.ServiceTime;
        }

        private void CheckReadyToRunning(IList<ProcessEntryState> pResults)
        {
            var readyProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.Ready);
            // Algoritmo de seleccion por prioridad.
            // Tomo el que tiene menos tiempo de cpu remantente.
            var processToDispatch = readyProcesses.MinBy(p => RemainingTime(p)) ?? throw new InvalidOperationException(nameof(CheckReadyToRunning));
            processToDispatch.Dispatch();
            // Recupero ServiceTime interrumpido
            if (this.ProcessStateRecovery.ContainsKey(processToDispatch.ProcessEntry.Name))
            {
                processToDispatch.StateTime = this.ProcessStateRecovery[processToDispatch.ProcessEntry.Name];
            }
        }
    }
}

