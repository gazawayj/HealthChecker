using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthChecker.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;

namespace HealthChecker.ViewModel
{
    public partial class HealthLogViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public ObservableCollection<HealthLog> healthLogs { get; } = new();
        public ObservableCollection<HealthLog> todaysCards { get; } = new();
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
                var logs = await healthLogService.GetHealthLogs();

                if (healthLogs.Count != 0)
                    healthLogs.Clear();

                foreach (var log in logs)
                {
                    healthLogs.Add(log);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get logs: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
                return;
            }

            //// Convert healthLogs to a string representation for display
            //var logsStringBuilder = new StringBuilder();
            //foreach (var log in healthLogs)
            //{
            //    logsStringBuilder.AppendLine($"Message: {log.Message}, Status: {log.Status}, Details: {log.Details}");
            //}
            //await Shell.Current.DisplayAlert("It Worked!", logsStringBuilder.ToString(), "OK");
            
        }

    }
}
