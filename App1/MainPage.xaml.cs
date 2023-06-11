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
            await SendSms(EntrySms.Text, numbers);
        }


        public async Task SendSms(string messageText,
            List<string> numbers)
        {
            try
            {
               // var requiredPermissions = new String[] { Manifest.Permission.SendSms };

                var number = numbers.First();
                //var message = new SmsMessage(messageText, numbers);
                //await Sms.ComposeAsync(message);
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
    }
}
