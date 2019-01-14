using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();

            modelLabel.Text = $"Model: {DeviceInfo.Model}";
            manufacturerLabel.Text = $"Manufacturer: {DeviceInfo.Manufacturer}";
            nameLabel.Text = $"Name: {DeviceInfo.Name}";
            versionStringLabel.Text = $"VersionString: {DeviceInfo.VersionString}";
            versionLabel.Text = $"Version: {DeviceInfo.Version}";
            platformLabel.Text = $"Platform: {DeviceInfo.Platform}";
            idiomLabel.Text = $"Idiom: {DeviceInfo.Idiom}";
            deviceTypeLabel.Text = $"DeviceType: {DeviceInfo.DeviceType}";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadDeviceDisplay();
            DeviceDisplay.MainDisplayInfoChanged += DeviceDisplay_MainDisplayInfoChanged;
        }

        protected override void OnDisappearing()
        {
            DeviceDisplay.MainDisplayInfoChanged -= DeviceDisplay_MainDisplayInfoChanged;

            base.OnDisappearing();
        }

        private void LoadDeviceDisplay()
        {
            screenWidthLabel.Text = $"Width: {DeviceDisplay.MainDisplayInfo.Width}";
            screenHeightLabel.Text = $"Height: {DeviceDisplay.MainDisplayInfo.Height}";
            screenDensityLabel.Text = $"Density: {DeviceDisplay.MainDisplayInfo.Density}";
            screenOrientationLabel.Text = $"Orientation: {DeviceDisplay.MainDisplayInfo.Orientation}";
            screenRotationLabel.Text = $"Rotation: {DeviceDisplay.MainDisplayInfo.Rotation}";
        }

        void DeviceDisplay_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            LoadDeviceDisplay();
        }

    }
}
