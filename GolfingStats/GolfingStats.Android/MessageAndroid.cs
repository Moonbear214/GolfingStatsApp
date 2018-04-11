using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

using Android.App;
using Android.Widget;
using GolfingStats.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace GolfingStats.Droid
{
    public class MessageAndroid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}