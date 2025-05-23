using HealthChecker.Models;
using HealthChecker.PageModels;

namespace HealthChecker.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageModel model)
        {
            InitializeComponent();
            BindingContext = model;
        }
    }
}