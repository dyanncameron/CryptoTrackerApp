using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using CryptoTracker.Model;
using Microsoft.AppCenter.Crashes;

namespace CryptoTracker
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "90982F12-0D45-4307-98F7-140B177C8114";
        private string baseImageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        


        public MainPage()
        {
            InitializeComponent();
            CoinListView.ItemsSource = GetCoins();

            

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            CoinListView.ItemsSource = GetCoins();

//            // try
//             {
//                 Crashes.GenerateTestCrash();
//             }
//             catch (Exception exception)
//             {
//                 Crashes.TrackError(exception, new Dictionary<string, string>() {
//                     { "IsCoins", "true"}
//                 });

                
//             }//
        }

        private  List<Coin> GetCoins()
        {
            List<Coin> coin;

            var client = new RestClient("http://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;ADA;LTC;DOGE");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);


            var response = client.Execute(request);

            coin = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coin)
            {
                if (!string.IsNullOrEmpty(c.id_icon))
                    c.icon_url = baseImageUrl + c.id_icon.Replace("-", "") + ".png";
                else
                    c.icon_url = ""; 
            }

            return coin;
        }

    }

}
