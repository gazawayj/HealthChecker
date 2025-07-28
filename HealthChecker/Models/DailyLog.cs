using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthChecker.Models
{
    class DailyLog
    {
        public string Date { get; set;  }
        public string CalsBurnt { get; set; }
        public string PrevSleepQual { get; set; }
        public string DailyCogFunction { get; set; }
        public string DailyLowAct { get; set; }
        public string DailyMedAct { get; set; }
        public string DailyHighAct { get; set; }

        public DailyLog()
        {
            //What type of information do you need, Jim? Day, Cals burn, Sleep Qual, Cog Function, Activity time (low, high, med)
            //Go get them!
            Date = string.Empty;
            CalsBurnt = string.Empty;
            PrevSleepQual = string.Empty;
            DailyCogFunction = string.Empty;
            DailyLowAct = string.Empty;
            DailyMedAct = string.Empty;
            DailyHighAct = string.Empty;
        }
    }

    [JsonSerializable(typeof(List<HealthLog>))]
    internal sealed partial class HealthLogContext : JsonSerializerContext
    {
    }
}
