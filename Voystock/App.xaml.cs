using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
#if !LOCAL
using System.ServiceModel.Web;
using Voystock.Communication;
#endif

namespace Voystock
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public static IVoyStockService Service { get;private set; }

#if !LOCAL
        public WebChannelFactory<IVoyStockService> ChanelFactory { get; set; }
#endif


        public static List<Scheme> AllSchemes { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
#if !LOCAL
            ChanelFactory = new WebChannelFactory<IVoyStockService>(new Uri("http://localhost:64923/"));
            ChanelFactory.Open();
            Service = ChanelFactory.CreateChannel();
#endif
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
#if !LOCAL
            Service = null;
            ChanelFactory.Close();
#endif
        }
    }
}
