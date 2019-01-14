using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class PhoneDialerPage : ContentPage
    {
        public PhoneDialerPage()
        {
            InitializeComponent();

            openDialerButton.Clicked += OpenDialerButton_Clicked;
        }

        void OpenDialerButton_Clicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(phoneNumberEntry.Text);
        }

    }
}
