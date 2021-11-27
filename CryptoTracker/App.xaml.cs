using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;

namespace CryptoTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {


            AppCenter.Start("android=07470aa5-a01e-4853-afaf-b63cb2733481;" +
                  "uwp={Your UWP App secret here};" +
                  "ios={Your iOS App secret here}",
                  typeof(Analytics), typeof(Crashes));
        }



        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
