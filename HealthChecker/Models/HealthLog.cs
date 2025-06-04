using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthChecker.Models
{
    public class HealthLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public HealthLog() 
        { 
            Timestamp = DateTime.Now;
            Message = string.Empty;
            Status = string.Empty;
            Details = string.Empty;
        }
    }
}
