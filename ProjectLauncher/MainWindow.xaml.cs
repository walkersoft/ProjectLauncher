using CommunityToolkit.Mvvm.Messaging;
using Hardcodet.Wpf.TaskbarNotification;
using System.ComponentModel;
using System.Windows;

namespace ProjectLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRecipient<ShowApplication>, IRecipient<ExitApplication>
    {
        public MainWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        void IRecipient<ExitApplication>.Receive(ExitApplication message)
        {
            Closing -= OnWindowClosing; // Prevents additional notification showing up during app shutdown
            Application.Current.Shutdown();
        }

        private void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            taskbarIcon.ShowBalloonTip("Project Launcher Running", "Application is running in the background. Left-click to open or Right-click for menu options.", BalloonIcon.None);
        }

        void IRecipient<ShowApplication>.Receive(ShowApplication message)
        {
            Show();
        }
    }
}