using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class EmailPage : ContentPage
    {
        public EmailPage()
        {
            InitializeComponent();

            sendButton.Clicked += SendButton_Clicked;
        }

        async void SendButton_Clicked(object sender, EventArgs e)
        {
            var message = new EmailMessage
            {
                To = new List<string> { toEntry.Text },
                Cc = new List<string> { ccEntry.Text },
                Bcc = new List<string> { bccEntry.Text },
                Subject = subjectEntry.Text,
                Body = bodyEditor.Text,
                BodyFormat = isHtmlSwitch.IsToggled ? EmailBodyFormat.Html : EmailBodyFormat.PlainText
            };
            await Email.ComposeAsync(message);
        }

    }
}
