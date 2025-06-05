using HealthChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthChecker.Services
{
    public class HealthLogService
    {
        //HttpClient httpClient;
        
        public HealthLogService()
        {
            //this.httpClient = new HttpClient();
            healthLogs = GetHealthLogs().Result;
        }

        public ICollection<HealthLog> healthLogs;
        public async Task<ICollection<HealthLog>> GetHealthLogs()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("SeedData.json");
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            return JsonSerializer.Deserialize(content, HealthLogContext.Default.ICollectionHealthLog);
        }
    }
}
