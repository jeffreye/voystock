using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Voystock.Communication;

namespace Voystock
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await UserSession.Open();
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await UserSession.Close();
        }
    }
}
