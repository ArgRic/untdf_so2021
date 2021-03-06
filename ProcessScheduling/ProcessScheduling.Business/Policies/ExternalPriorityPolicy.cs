namespace ProcessScheduling.Scheduler.Policies
{
    using System;
    using System.Collections.Generic;
    using ProcessScheduling.Scheduler.Model;

    public class ExternalPriorityPolicy : AbstractPolicy
    {
        private Dictionary<string, int> ProcessStateRecovery;

        public ExternalPriorityPolicy(ProcessSchedulerConfig config) : base(config)
        {
            ProcessStateRecovery = new Dictionary<string, int>();
        }

        public override bool UpdateProcessState(IList<ProcessEntryState> processes)
        {
            // Arrivos y Salidas
            this.CommonChecks(processes);

            // Salgo si termino la tanda.
            if (processes.All(p => p.ProcessState == ProcessStateEnum.Terminated))
            {
                return true;
            }

            // PrioridadExterna es preemptiva. El proceso que aun corre puede interrumpirse
            if (processes.Any(p => p.ProcessState == ProcessStateEnum.Running))
            {
                this.CheckRunningToReadyByPriority(processes);
            }

            // Si el proceso no fue interrumpido y sigue corriendo. Salgo
            if (processes.Any(p => p.ProcessState == ProcessStateEnum.Running))
            {
                return true;
            }

            if (processes.Any(p => p.ProcessState == ProcessStateEnum.Ready))
            {
                // Hay procesos en espera o corriendo. El Scheduler se encuentra conmutando. 
                CurrentExchangeTime++;
                if (CurrentExchangeTime >= config.OverheadTimeToExchange)
                {
                    CurrentExchangeTime = 0;
                    this.CheckReadyToRunning(processes);
                }
            }

            return true;
        }

        private void CheckRunningToReadyByPriority(IList<ProcessEntryState> pResults)
        {
            var runningProcess = pResults.FirstOrDefault(p => p.ProcessState == ProcessStateEnum.Running);
            if (runningProcess is not null)
            {
                var higherPriorityProcess = pResults.FirstOrDefault(p =>
                p.ProcessState == ProcessStateEnum.Ready
                && p.ProcessEntry.Priority > runningProcess.ProcessEntry.Priority);
                if (higherPriorityProcess is not null)
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

        private void CheckReadyToRunning(IList<ProcessEntryState> pResults)
        {
            var readyProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.Ready);
            // Algoritmo de seleccion por prioridad.
            // Tomo el que tiene mas prioridad
            var processToDispatch = readyProcesses.MaxBy(p => p.ProcessEntry.Priority) ?? throw new InvalidOperationException(nameof(CheckReadyToRunning));
            processToDispatch.Dispatch();
            // Recupero ServiceTime interrumpido
            if (this.ProcessStateRecovery.ContainsKey(processToDispatch.ProcessEntry.Name))
            {
                processToDispatch.StateTime = this.ProcessStateRecovery[processToDispatch.ProcessEntry.Name];
            }
        }
    }
}
