using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace ProjectLauncher
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<ProjectDisplayItem> ProjectDisplayItems { get; set; } = [];

        public MainWindowViewModel()
        {
            // testing
            ProjectDisplayItems.Add(new("Project Launcher", true));
            ProjectDisplayItems.Add(new("Expense Tracker", true));
        }

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

    internal record ProjectDisplayItem(string ProjectName, bool IsActive);
}
