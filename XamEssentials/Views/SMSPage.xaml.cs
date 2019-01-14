using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class SMSPage : ContentPage
    {
        public SMSPage()
        {
            InitializeComponent();

            sendButton.Clicked += SendButton_Clicked;
        }

        void SendButton_Clicked(object sender, EventArgs e)
        {
            var message = new SmsMessage(messageTextEntry.Text, new List<string> { recipientEntry.Text });
            Sms.ComposeAsync(message);
        }

    }
}
