using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ServiceModel.Web;
using Voystock.Communication;

namespace Voystock
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public static IVoyStockService Service { get;private set; }

        public WebChannelFactory<IVoyStockService> ChanelFactory { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ChanelFactory = new WebChannelFactory<IVoyStockService>();
            Service = ChanelFactory.CreateChannel();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Service = null;
            ChanelFactory.Close();
        }
    }
}
