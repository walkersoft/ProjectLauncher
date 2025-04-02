using CommunityToolkit.Mvvm.Messaging;
using System.Windows;

namespace ProjectLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IRecipient<ExitApplication>
    {
        public MainWindow()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.RegisterAll(this);
        }

        private void CreateTrayMenu()
        {

        }

        private void OnWindowClosed(object sender, EventArgs e)
        {

        }

        void IRecipient<ExitApplication>.Receive(ExitApplication message)
        {
            Application.Current.Shutdown();
        }
    }
}