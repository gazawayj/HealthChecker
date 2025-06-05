using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HealthChecker.Models;

namespace HealthChecker.PageModels
{
    public partial class MainPageModel : ObservableObject
    {
        [ObservableProperty]
        private ICollection<HealthLog> healthLogs = [];

        [ObservableProperty]
        private ICollection<HealthLog> pastNotifications = [];

        public MainPageModel()
        {
            
        }

        [RelayCommand]
        private async Task Refresh()
        {
            await Task.CompletedTask;
        }
    }
}