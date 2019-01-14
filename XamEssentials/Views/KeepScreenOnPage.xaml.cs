using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class KeepScreenOnPage : ContentPage
    {
        public KeepScreenOnPage()
        {
            InitializeComponent();

            awakeButton.Clicked += AwakeButton_Clicked;
            restButton.Clicked += RestButton_Clicked;
        }

        void AwakeButton_Clicked(object sender, EventArgs e)
        {
            DeviceDisplay.KeepScreenOn = true;
            neverSleepLabel.IsVisible = DeviceDisplay.KeepScreenOn;
        }

        void RestButton_Clicked(object sender, EventArgs e)
        {
            DeviceDisplay.KeepScreenOn = false;
            neverSleepLabel.IsVisible = DeviceDisplay.KeepScreenOn;
        }

    }
}
