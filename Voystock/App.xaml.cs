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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                UserSession.Open().Wait();
            }
            catch
            {
                MessageBox.Show("服务器都连不上,你用个鬼", "大事不妙了");
                Shutdown();
            }
        }

        private async void Application_Exit(object sender, ExitEventArgs e)
        {
            await UserSession.Close();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "大事不妙了");
        }
    }
}
