using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessScheduling.WinApp.Model
{
    public enum PolicyEnum
    {
        FirstComeFirstServe,
        ExternalPriotity,
        RoundRobin,
        ShortestProcessNext,
        ShortestRemainingTime,
    }
}
