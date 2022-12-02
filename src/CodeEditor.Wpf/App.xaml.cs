using CodeEditor.Wpf.ViewModels;
using CodeEditor.Wpf.Views;
using System.Windows;

namespace CodeEditor.Wpf
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainView();
            var dataContext = new MainViewModel();
            dataContext.RequestClose += CloseApplication;
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void CloseApplication()
        {
            MainWindow.Close();
        }
    }
}