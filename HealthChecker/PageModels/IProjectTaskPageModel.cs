using CommunityToolkit.Mvvm.Input;
using HealthChecker.Models;

namespace HealthChecker.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}