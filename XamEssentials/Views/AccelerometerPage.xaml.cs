using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class AccelerometerPage : ContentPage
    {
        public AccelerometerPage()
        {
            InitializeComponent();

            speedPicker.ItemsSource = Enum.GetNames(typeof(SensorSpeed));

            startButton.Clicked += StartButton_Clicked;
            stopButton.Clicked += StopButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
        }              

        protected override void OnDisappearing()
        {
            Accelerometer.ReadingChanged -= Accelerometer_ReadingChanged;
            base.OnDisappearing();
        }

        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                xLabel.Text = e.Reading.Acceleration.X.ToString();
                yLabel.Text = e.Reading.Acceleration.Y.ToString();
                zLabel.Text = e.Reading.Acceleration.Z.ToString();
            });
        }

        void StartButton_Clicked(object sender, EventArgs e)
        {
            Accelerometer.Start((SensorSpeed)speedPicker.SelectedIndex);
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            Accelerometer.Stop();
        }

    }
}
