// MainView.xaml.cs
using System.Windows;
using WPF_TimeTracker.ViewModels;

namespace WPF_TimeTracker.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
