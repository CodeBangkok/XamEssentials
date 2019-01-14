using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class SharePage : ContentPage
    {
        public SharePage()
        {
            InitializeComponent();

            requestButton.Clicked += RequestButton_Clicked;
        }

        async void RequestButton_Clicked(object sender, EventArgs e)
        {
            var request = new ShareTextRequest
            {
                Title = titleEntry.Text,
                Subject = subjectEntry.Text,
                Text = shareTextSwitch.IsToggled ? textEntry.Text : null,
                Uri = shareUriSwitch.IsToggled ? uriEntry.Text : null
            };
            await Share.RequestAsync(request);
        }

    }
}
