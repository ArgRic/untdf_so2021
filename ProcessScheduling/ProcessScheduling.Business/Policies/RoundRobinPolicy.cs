using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.Scheduler.Policies
{
    public class RoundRobinPolicy : AbstractPolicy
    {
        private int QuantumClock;
        private Dictionary<string, int> ProcessStateRecovery;

        public RoundRobinPolicy(ProcessSchedulerConfig config) : base(config)
        {
            if (config.Quantum < 1) { throw new ArgumentException("Quantum válido requerido"); }
            ProcessStateRecovery = new Dictionary<string, int>();
            QuantumClock = 0;
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

            // RoundRobin es preemptivo. El proceso que aun corre puede interrumpirse
            if (pResults.Any(p => p.ProcessState == ProcessStateEnum.Running))
            {
                QuantumClock = QuantumClock >= config.Quantum ? 0 : QuantumClock + 1;
                this.CheckRunningToReadyByQuantum(pResults, config.Quantum, QuantumClock);
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
                    QuantumClock = 0;
                    this.CheckReadyToRunning(pResults);
                }
            }

            return true;
        }

        private void CheckRunningToReadyByQuantum(IList<ProcessEntryState> pResults, int quantum, int clock)
        {
            var runningProcess = pResults.FirstOrDefault(p => p.ProcessState == ProcessStateEnum.Running);
            if (runningProcess is not null)
            {
                if( clock >= quantum)
                {
                    // El proceso se interrumpe por quantum.
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
            // Algoritmo de seleccion FCFS.
            // Tomo el que esta hace mas tiempo en estado de espera.
            var processToDispatch = readyProcesses.MaxBy(p => p.StateTime) ?? throw new InvalidOperationException(nameof(CheckReadyToRunning));
            processToDispatch.Dispatch();
            // Recupero ServiceTime interrumpido
            if (this.ProcessStateRecovery.ContainsKey(processToDispatch.ProcessEntry.Name)) 
            {
                processToDispatch.StateTime = this.ProcessStateRecovery[processToDispatch.ProcessEntry.Name];
            }
        }
    }
}
