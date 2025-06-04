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
            const int newheight = 685;
            const int newwidth = 1000;

            var wins = new Window(new AppShell());
            wins.Height = wins.MinimumHeight = wins.MaximumHeight = newheight;
            wins.Width = wins.MinimumWidth = wins.MaximumWidth = newwidth;
            return wins;
        }
    }
}