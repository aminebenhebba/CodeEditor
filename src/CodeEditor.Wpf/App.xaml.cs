using CodeEditor.Wpf.Commands;
using CodeEditor.Wpf.Services;
using CodeEditor.Wpf.ViewModels;
using CodeEditor.Wpf.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CodeEditor.Wpf
{
    public partial class App : Application
    {
        private readonly IHost _appHost;

        public App()
        {
            _appHost = Host.CreateDefaultBuilder()
                          .ConfigureServices(ConfigureServices)
                          .Build();
        }

        protected async override void OnStartup(StartupEventArgs e)
        {
            await _appHost.StartAsync();

            MainWindow = _appHost.Services.GetRequiredService<MainView>();
            var dataContext = _appHost.Services.GetRequiredService<MainViewModel>();
            dataContext.RequestClose += CloseApplication;
            MainWindow.DataContext = dataContext;
            MainWindow.Show();

            base.OnStartup(e);
        }

        private void CloseApplication()
        {
            MainWindow.Close();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _appHost.StopAsync();

            base.OnExit(e);
        }

        private void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainView>();

            services.AddSingleton<ICommandFactory, CommandFactory>();
            services.AddTransient<ICompileService, CompileService>();
            services.AddTransient<IIOService, IOService>();
        }
    }
}