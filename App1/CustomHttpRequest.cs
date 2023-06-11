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


namespace App1
{
    internal class CustomHttpResponse : HttpResponse
    {
        public override string Get(string key)
        {
            // Provide your custom implementation here
            // You can modify the logic to retrieve the desired value based on the key
            if (key == "CustomKey")
            {
                return "CustomValue";
            }
            else
            {
                return base.Get(key);
            }
        }
    }
}
