using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthChecker.Models;
using System.Collections.ObjectModel;

namespace HealthChecker.ViewModel
{
    public partial class HealthLogViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public ObservableCollection<HealthLog> HealthLogs { get; } = new();
        HealthLogService healthLogService;

        public HealthLogViewModel(HealthLogService healthLogService)
        {
            this.healthLogService = healthLogService;
            Title = "Health Logs";
        }

        [RelayCommand]
        async Task GetHealthLogsAsync()
        {
            try
            {
                HealthLogs.Clear();
                var logs = await healthLogService.GetHealthLogs();

                foreach (var log in logs)
                {
                    HealthLogs.Add(log);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, e.g., log them or show a message to the user
                Console.WriteLine($"Error fetching health logs: {ex.Message}");
            }
        }

    }
}
