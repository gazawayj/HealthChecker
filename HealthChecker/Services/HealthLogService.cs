﻿using HealthChecker.Models;
using System.Text.Json;

namespace HealthChecker.Services
{
    public class HealthLogService
    {
        //give the option to go online later
        private List<HealthLog> healthLogs = new List<HealthLog>(); // Initialize to avoid nullability issues

        public HealthLogService()
        {
        }

        public async Task<List<HealthLog>> GetHealthLogs()
        {
            if (healthLogs?.Count > 0)
                return healthLogs;

            using var stream = await FileSystem.OpenAppPackageFileAsync("SeedData.json");
            using var reader = new StreamReader(stream);
            var content = await reader.ReadToEndAsync();
            healthLogs = JsonSerializer.Deserialize(content, HealthLogContext.Default.ListHealthLog);

            return healthLogs;
        }
    }
}
