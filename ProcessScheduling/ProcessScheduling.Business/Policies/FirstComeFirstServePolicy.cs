namespace ProcessScheduling.Scheduler.Policies
{
    using System;
    using System.Collections.Generic;
    using ProcessScheduling.Scheduler.Model;

    public class FirstComeFirstServePolicy : AbstractPolicy
    {

        public FirstComeFirstServePolicy(ProcessSchedulerConfig config): base(config)
        {
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

            // FCFS es no preemptivo. Salgo si el CPU esta siendo utilizado.
            if (processes.Any(p => p.ProcessState == ProcessStateEnum.Running))
            {
                return true;
            }

            // No hay procesos corriendo.
            if (processes.Any(p => p.ProcessState == ProcessStateEnum.Ready))
            {
                // Hay procesos en espera. El Scheduler se encuentra conmutando. 
                CurrentExchangeTime++;
                if (CurrentExchangeTime >= config.OverheadTimeToExchange)
                {
                    CurrentExchangeTime = 0;
                    this.CheckReadyToRunning(processes);
                }
            }

            return true;
        }

        private void CheckReadyToRunning(IList<ProcessEntryState> pResults)
        {
            var readyProcesses = pResults.Where(p => p.ProcessState == ProcessStateEnum.Ready);
            // Algoritmo de seleccion FCFS.
            // Tomo el que esta hace mas tiempo en estado de espera.
            var processToDispatch = readyProcesses.MaxBy(p => p.StateTime) ?? throw new InvalidOperationException(nameof(CheckReadyToRunning));
            processToDispatch.Dispatch();
        }
    }
}
