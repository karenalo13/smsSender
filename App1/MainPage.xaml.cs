using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Android.Telephony;
using Android;
using System.Net.Http;
using Java.Util;
using Org.Apache.Http.Protocol;
using Newtonsoft.Json;
using System.Net;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonSender_Clicked(object sender, EventArgs e)
        {
            List<string> numbers = new List<string>
            {
                EntryNumber.Text
            };
            //await SendSms(EntrySms.Text, numbers);
            await CallAPI();
        }


        public async Task SendSms(string messageText,
            List<string> numbers)
        {
            try
            {
                var number = numbers.First();
                SmsManager smsManager = SmsManager.Default;
                smsManager.SendTextMessage(number, null, messageText, null, null);
            }
            catch (FeatureNotSupportedException e)
            {

            }
            catch (Exception ex)
            {

            }
        }

        private async Task CallAPI()
        {

            try
            {
                string uri = "http://192.168.100.19:5000/messages";

                HttpClient httpClient = new HttpClient();

                HttpResponseMessage response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    // The request was successful. Retrieve the response content.
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // Process or display the response as needed.
                    var listOfObjects = JsonConvert.DeserializeObject<List<Inserted>>(responseBody);
                    Console.WriteLine(responseBody);
                }
                else
                {
                    // The request was not successful. Handle the error.
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
