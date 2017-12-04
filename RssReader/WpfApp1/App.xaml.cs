using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Unity;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            container.RegisterType<ISaveUtility, SaveUtility>();
            container.RegisterType<IFeedItemManager, FeedItemManager>();
            container.RegisterType<IFeedManager, FeedManager>();
            container.RegisterType<IApplicationFeedManager, ApplicationFeedManager>();

            MainViewModel mainViewModel = container.Resolve<MainViewModel>();

            MainWindow mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
        }
    }
}
