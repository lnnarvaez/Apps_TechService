using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps_TechService.Models.Enums
{
    public enum ServiceStatus
    {
        Pending = 1,
        InDiagnosis = 2,
        InProgress = 3,
        Completed = 4,
        Delivered = 5,
        Cancelled = 6
    }
} //end namespace
