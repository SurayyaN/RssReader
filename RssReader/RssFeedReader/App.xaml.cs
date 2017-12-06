using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Unity;
using RssFeedReader.Services;

namespace RssFeedReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup" /> event. this is where all the dependencies are registered
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            container.RegisterType<ISaveUtility, SaveUtility>();
            container.RegisterType<ISavedFeedItemManager, SavedFeedItemManager>();
            container.RegisterType<IFeedItemManager, FeedItemManager>();
            container.RegisterType<IFeedManager, FeedManager>();
            container.RegisterType<IApplicationFeedManager, ApplicationFeedManager>();

            MainViewModel mainViewModel = container.Resolve<MainViewModel>();

            MainWindow mainWindow = new MainWindow { DataContext = mainViewModel };
            mainWindow.Show();
        }
    }
}
