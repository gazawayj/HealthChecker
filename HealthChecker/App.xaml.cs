namespace HealthChecker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var wins = new Window(new AppShell());
            return wins;
        }
    }
}