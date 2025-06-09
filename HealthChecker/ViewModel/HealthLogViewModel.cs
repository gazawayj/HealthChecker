using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthChecker.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Maui.Views;
using System.Text;

namespace HealthChecker.ViewModel
{
    public partial class HealthLogViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;

        public ObservableCollection<HealthLog> pastHealthLogs { get; } = new();
        public ObservableCollection<HealthLog> todaysHealthLogs { get; } = new();
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

                if (pastHealthLogs.Count != 0)
                    pastHealthLogs.Clear();

                foreach (var log in logs)
                {
                    pastHealthLogs.Add(log);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get logs: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
                return;
            }
        }

        [RelayCommand]
        public void CreateLogPopup()
        {
            var popup = new LogPopup();
            popup.BindingContext = this;
        }

        [RelayCommand]
        async Task GetTodaysLogsAsync()
        {
            try
            {
                var logs = await healthLogService.GetHealthLogs();

                if (pastHealthLogs.Count != 0)
                    pastHealthLogs.Clear();

                foreach (var log in logs)
                {
                    pastHealthLogs.Add(log);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get logs: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
                return;
            }
        }
    }
}
