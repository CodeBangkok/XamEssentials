using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class FlashlightPage : ContentPage
    {
        bool isOn;

        public FlashlightPage()
        {
            InitializeComponent();

            flashlightButton.Clicked += FlashlightButton_Clicked;
        }

        async void FlashlightButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (isOn)
                {
                    await Flashlight.TurnOffAsync();
                    isOn = false;
                }
                else
                {
                    await Flashlight.TurnOnAsync();
                    isOn = true;
                }

                onLabel.IsVisible = isOn;
                offLabel.IsVisible = !isOn;
            }
            catch (FeatureNotSupportedException)
            {
                notSupportLabel.IsVisible = true;
            }
        }
    }
}
