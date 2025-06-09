using HealthChecker.ViewModel;

namespace HealthChecker.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(HealthLogViewModel model)
        {
            InitializeComponent();
            BindingContext = model;
            model.GetHealthLogsCommand.Execute(null);
        }
    }
}