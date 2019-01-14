using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class GeolocationPage : ContentPage
    {
        public GeolocationPage()
        {
            InitializeComponent();
            refreshLastKnownButton.Clicked += RefreshLastKnownButton_Clicked;
            refreshCurrentButton.Clicked += RefreshCurrentButton_Clicked;
            calculateButton.Clicked += CalculateButton_Clicked;

            accuraciesPicker.ItemsSource = Enum.GetNames(typeof(GeolocationAccuracy));
        }

        void RefreshLastKnownButton_Clicked(object sender, EventArgs e)
        {
            GetLastKnownLocation();
        }

        void RefreshCurrentButton_Clicked(object sender, EventArgs e)
        {
            GetCurrentLocation();
        }


        private async void GetLastKnownLocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            lastLocationLabel.Text = $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n" +
                $"Accuracy: {location.Accuracy}\n" +
                $"Altitude: {location.Altitude}\n" +
                $"Heading: {location.Course}\n" +
                $"Speed: {location.Speed}\n" +
                $"Date (UTC): {location.Timestamp:d}\n" +
                $"Time (UTC): {location.Timestamp:T}";
        }

        private async void GetCurrentLocation()
        {
            var request = new GeolocationRequest((GeolocationAccuracy)accuraciesPicker.SelectedIndex, TimeSpan.FromSeconds(10));
            var location = await Geolocation.GetLocationAsync(request);
            currentLocationLabel.Text = $"Latitude: {location.Latitude}\n" +
                $"Longitude: {location.Longitude}\n" +
                $"Accuracy: {location.Accuracy}\n" +
                $"Altitude: {location.Altitude}\n" +
                $"Heading: {location.Course}\n" +
                $"Speed: {location.Speed}\n" +
                $"Date (UTC): {location.Timestamp:d}\n" +
                $"Time (UTC): {location.Timestamp:T}";
        }

        void CalculateButton_Clicked(object sender, EventArgs e)
        {
            var locationA = new Location(13.7265503, 100.5087556);
            var locationB = new Location(13.7270342, 100.5108728);
            var distance = Location.CalculateDistance(locationA, locationB, DistanceUnits.Kilometers);
            calculatelabel.Text = $"A => B distance {distance} km";
        }

    }
}
