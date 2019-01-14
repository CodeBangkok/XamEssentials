using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class VibrationPage : ContentPage
    {
        public VibrationPage()
        {
            InitializeComponent();

            vibrateButton.Clicked += VibrateButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;
        }

        void VibrateButton_Clicked(object sender, EventArgs e)
        {
            Vibration.Vibrate(durationSlider.Value);
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {
            Vibration.Cancel();
        }

    }
}
