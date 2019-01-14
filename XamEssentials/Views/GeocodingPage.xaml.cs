using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace XamEssentials.Views
{
    public partial class GeocodingPage : ContentPage
    {
        double latitude = 13.7265503;
        double longitude = 100.5087556;

        public GeocodingPage()
        {
            InitializeComponent();

            latitudeEntry.Text = latitude.ToString();
            longitudeEntry.Text = longitude.ToString();
            addressEntry.Text = "299 Charoen Nakhon Rd, Khwaeng Khlong Ton Sai, Khet Khlong San, Krung Thep Maha Nakhon 10600";

            detectPlacemarksButton.Clicked += DetectPlacemarksButton_Clicked;
            detectLocationButton.Clicked += DetectLocationButton_Clicked;
        }

        async void DetectPlacemarksButton_Clicked(object sender, EventArgs e)
        {
            var location = new Location(latitude, longitude);
            var placemarks = await Geocoding.GetPlacemarksAsync(location);
            var placemark = placemarks.FirstOrDefault();

            if (placemark != null)
            {
                geocodeAddressLabel.Text =
                    $"AdminArea: {placemark.AdminArea}\n" +
                    $"CountryCode: {placemark.CountryCode}\n" +
                    $"CountryName: {placemark.CountryName}\n" +
                    $"FeatureName: {placemark.FeatureName}\n" +
                    $"Locality: {placemark.Locality}\n" +
                    $"PostalCode: {placemark.PostalCode}\n" +
                    $"SubAdminArea: {placemark.SubAdminArea}\n" +
                    $"SubLocality: {placemark.SubLocality}\n" +
                    $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
                    $"Thoroughfare: {placemark.Thoroughfare}\n";
            }
            else geocodeAddressLabel.Text = "Unable to detect placemarks.";
        }

        async void DetectLocationButton_Clicked(object sender, EventArgs e)
        {
            var locations = await Geocoding.GetLocationsAsync(addressEntry.Text);
            var location = locations.FirstOrDefault();
            if (location != null)
            {
                geocodePositionLabel.Text =
                    $"Latitude: {location.Latitude}\n" +
                    $"Longitude: {location.Longitude}\n";
            }
            else geocodePositionLabel.Text = "Unable to detect locations";
        }

    }
}
