using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace HealthChecker.Models
{
    public class HealthLog
    {
        public string Message { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public HealthLog() 
        { 
            Message = "234";
            Status = string.Empty;
            Details = string.Empty;
        }
    }
    [JsonSerializable(typeof(List<HealthLog>))]
    internal sealed partial class HealthLogContext : JsonSerializerContext
    {

    }
}
