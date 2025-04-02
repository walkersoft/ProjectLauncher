using CommunityToolkit.Mvvm.Messaging;
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
            Application.Current.Shutdown();
        }

        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        void IRecipient<ShowApplication>.Receive(ShowApplication message)
        {
            Show();
        }
    }
}