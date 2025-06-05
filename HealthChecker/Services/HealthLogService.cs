using HealthChecker.Models;
using System.Text.Json;

namespace HealthChecker.Services
{
    public class HealthLogService
    {        
        public HealthLogService()
        {
            healthLogs = GetHealthLogs().Result;
        }

        public ICollection<HealthLog> healthLogs;
        public async Task<ICollection<HealthLog>> GetHealthLogs()
        {
            if (healthLogs?.Count > 0)
                return healthLogs;

            using var stream = await FileSystem.OpenAppPackageFileAsync("SeedData.json");
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            healthLogs = JsonSerializer.Deserialize(content, HealthLogContext.Default.ICollectionHealthLog) ?? new List<HealthLog>();
            return healthLogs;
        }
    }
}
