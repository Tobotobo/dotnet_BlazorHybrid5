using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace BlazorHybrid.Wpf;

static class Program
{
    [STAThread]
    static void Main()
    {
        var app = new App();

        app.Services.AddWpfBlazorWebView();

        app.Run();
    }

    class App : Application
    {
        public IServiceCollection Services { get; } = new ServiceCollection();

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window
            {
                Title = "BlazorHybrid.Wpf",
                Width = 1024,
                Height = 700,
            };

            var blazorWebView = new BlazorWebView
            {
                HostPage = "wwwroot\\index.html",
                Services = Services.BuildServiceProvider(),
                RootComponents = { new RootComponent
                {
                    Selector = "#app",
                    ComponentType = typeof(BlazorHybrid.View.Components.Routes),
                } },
            };
            window.Content = blazorWebView;

            window.Show();
        }
    }
}