using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class MagnetometerPage : ContentPage
    {
        public MagnetometerPage()
        {
            InitializeComponent();
            speedPicker.ItemsSource = Enum.GetNames(typeof(SensorSpeed));

            startButton.Clicked += StartButton_Clicked;
            stopButton.Clicked += StopButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
        }

        protected override void OnDisappearing()
        {
            Magnetometer.ReadingChanged -= Magnetometer_ReadingChanged;
            base.OnDisappearing();
        }

        void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                xLabel.Text = e.Reading.MagneticField.X.ToString();
                yLabel.Text = e.Reading.MagneticField.Y.ToString();
                zLabel.Text = e.Reading.MagneticField.Z.ToString();
            });
        }

        void StartButton_Clicked(object sender, EventArgs e)
        {
            Magnetometer.Start((SensorSpeed)speedPicker.SelectedIndex);
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            Magnetometer.Stop();
        }

    }
}