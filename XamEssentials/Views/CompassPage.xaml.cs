using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class CompassPage : ContentPage
    {
        public CompassPage()
        {
            InitializeComponent();
            speedPicker.ItemsSource = Enum.GetNames(typeof(SensorSpeed));

            startButton.Clicked += StartButton_Clicked;
            stopButton.Clicked += StopButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Compass.ReadingChanged += Compass_ReadingChanged;
        }

        protected override void OnDisappearing()
        {
            Compass.ReadingChanged -= Compass_ReadingChanged;
            base.OnDisappearing();
        }

        void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                compassLabel.Text = e.Reading.HeadingMagneticNorth.ToString();
            });
        }


        void StartButton_Clicked(object sender, EventArgs e)
        {
            Compass.Start((SensorSpeed)speedPicker.SelectedIndex);
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            Compass.Stop();
        }

    }
}