using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Policies
{
    public class ShortestProcessNextPolicy : AbstractPolicy
    {
        public ShortestProcessNextPolicy(ProcessSchedulerConfig config):base(config)
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

            // SPN es no preemptivo. Salgo si el CPU esta siendo utilizado.
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
            // Algoritmo de seleccion ShortestProcessNext.
            // Tomo el que requiere menos service time total.
            var processToDispatch = readyProcesses.MinBy(p => (p.ProcessEntry.BurstTime * p.ProcessEntry.BurstsQtyToComplete)) ?? throw new InvalidOperationException(nameof(CheckReadyToRunning));
            processToDispatch.Dispatch();
        }
    }
}
