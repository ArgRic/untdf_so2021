using ProcessScheduling.Scheduler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.ViewModel
{
    public class TandaRecord
    {
        public string Nombre { get; set; }
        public int TiempoDeArribo { get; set; }
        public int RafagasCPUParaTerminar { get; set; }
        public int DuracionRafagaCPU { get; set; }
        public int DuracionRafagaIO { get; set; }
        public int PrioridadExterna { get; set; }

        public TandaRecord()
        {
            this.Nombre = String.Empty;
        }

        public ProcessEntry ToProcessEntry()
        {
            var entry = new ProcessEntry
            {
                Name = Nombre,
                ArrivalTime = TiempoDeArribo,
                BurstsQtyToComplete = RafagasCPUParaTerminar,
                BurstTime = DuracionRafagaCPU,
                IOBurstTime = DuracionRafagaIO,
                Priority = PrioridadExterna
            };

            return entry;
            
        }
    }

}
