using System.Windows;
using WichtelApp.UI;

namespace WichtelApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainView = new MainView() { DataContext = new MainViewModel() };
            mainView.Show();
        }
    }
}
