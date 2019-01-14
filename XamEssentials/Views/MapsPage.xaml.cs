using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class MapsPage : ContentPage
    {
        double latitude = 13.7265503;
        double longitude = 100.5087556;

        public MapsPage()
        {
            InitializeComponent();

            navigationModePicker.ItemsSource = Enum.GetNames(typeof(NavigationMode));
            nameEntry.Text = "ICON SIAM";
            latitudeEntry.Text = latitude.ToString();
            longitudeEntry.Text = longitude.ToString();
            openCoordinateButton.Clicked += OpenCoordinateButton_Clicked;

            thoroughfareEntry.Text = "ซอย เจริญนคร";
            localityEntry.Text = "Bangkok";
            adminAreaEntry.Text = "Krung Thep Maha Nakhon";
            countryEntry.Text = "Thailand";
            zipCodeEntry.Text = "10600";
            openAddressButton.Clicked += OpenAddressButton_Clicked;
        }

        async void OpenCoordinateButton_Clicked(object sender, EventArgs e)
        {
            var option = new MapLaunchOptions
            {
                Name = nameEntry.Text,
                NavigationMode = (NavigationMode)navigationModePicker.SelectedIndex
            };
            await Map.OpenAsync(latitude, longitude, option);

        }

        async void OpenAddressButton_Clicked(object sender, EventArgs e)
        {
            var placemark = new Placemark
            {
                Locality = localityEntry.Text,
                AdminArea = adminAreaEntry.Text,
                CountryName = countryEntry.Text,
                Thoroughfare = thoroughfareEntry.Text,
                PostalCode = zipCodeEntry.Text
            };
            var option = new MapLaunchOptions
            {
                Name = nameEntry.Text,
                NavigationMode = (NavigationMode)navigationModePicker.SelectedIndex
            };
            await Map.OpenAsync(placemark, option);
        }

    }
}
