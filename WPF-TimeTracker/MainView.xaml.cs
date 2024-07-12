using System.Windows;
using System.Windows.Controls;

namespace WPF_TimeTracker.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Timers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new TimerView());
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryView());
        }

        private void Reports_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsView());
        }
    }
}
