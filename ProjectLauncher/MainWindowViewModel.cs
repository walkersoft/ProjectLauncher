using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace ProjectLauncher
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        [RelayCommand]
        public static void OnApplicationClosed()
        {
            WeakReferenceMessenger.Default.Send(new ExitApplication());
        }

        [RelayCommand]
        public static void OnApplicationOpened()
        {
            WeakReferenceMessenger.Default.Send(new ShowApplication());
        }

    }
}
