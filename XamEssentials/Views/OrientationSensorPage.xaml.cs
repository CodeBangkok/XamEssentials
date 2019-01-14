using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class OrientationSensorPage : ContentPage
    {
        public OrientationSensorPage()
        {
            InitializeComponent();
            speedPicker.ItemsSource = Enum.GetNames(typeof(SensorSpeed));

            startButton.Clicked += StartButton_Clicked;
            stopButton.Clicked += StopButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
        }

        protected override void OnDisappearing()
        {
            OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
            base.OnDisappearing();
        }

        void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                xLabel.Text = e.Reading.Orientation.X.ToString();
                yLabel.Text = e.Reading.Orientation.Y.ToString();
                zLabel.Text = e.Reading.Orientation.Z.ToString();
            });
        }

        void StartButton_Clicked(object sender, EventArgs e)
        {
            OrientationSensor.Start((SensorSpeed)speedPicker.SelectedIndex);
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            OrientationSensor.Stop();
        }

    }
}