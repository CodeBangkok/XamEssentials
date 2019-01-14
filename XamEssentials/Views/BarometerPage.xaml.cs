using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class BarometerPage : ContentPage
    {
        public BarometerPage()
        {
            InitializeComponent();
            speedPicker.ItemsSource = Enum.GetNames(typeof(SensorSpeed));

            startButton.Clicked += StartButton_Clicked;
            stopButton.Clicked += StopButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Barometer.ReadingChanged += Barometer_ReadingChanged;
        }

        protected override void OnDisappearing()
        {
            Barometer.ReadingChanged -= Barometer_ReadingChanged;
            base.OnDisappearing();
        }

        void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                pressureLabel.Text = e.Reading.PressureInHectopascals.ToString();
            });
        }

        void StartButton_Clicked(object sender, EventArgs e)
        {
            Barometer.Start((SensorSpeed)speedPicker.SelectedIndex);
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            Barometer.Stop();
        }

    }
}