using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class GyroscopePage : ContentPage
    {
        public GyroscopePage()
        {
            InitializeComponent();
            speedPicker.ItemsSource = Enum.GetNames(typeof(SensorSpeed));

            startButton.Clicked += StartButton_Clicked;
            stopButton.Clicked += StopButton_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
        }

        protected override void OnDisappearing()
        {
            Gyroscope.ReadingChanged -= Gyroscope_ReadingChanged;
            base.OnDisappearing();
        }

        void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                xLabel.Text = e.Reading.AngularVelocity.X.ToString();
                yLabel.Text = e.Reading.AngularVelocity.Y.ToString();
                zLabel.Text = e.Reading.AngularVelocity.Z.ToString();
            });
        }

        void StartButton_Clicked(object sender, EventArgs e)
        {
            Gyroscope.Start((SensorSpeed)speedPicker.SelectedIndex);
        }

        void StopButton_Clicked(object sender, EventArgs e)
        {
            Gyroscope.Stop();
        }

    }
}