using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class BatteryPage : ContentPage
    {
        public BatteryPage()
        {
            InitializeComponent();

            GetBatteryInfo();
            GetEnergySaverStatus();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
        }

        protected override void OnDisappearing()
        {
            Battery.BatteryInfoChanged -= Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged -= Battery_EnergySaverStatusChanged;

            base.OnDisappearing();
        }

        private void GetBatteryInfo()
        {
            levelLabel.Text = $"Level: {Battery.ChargeLevel}";
            stateLabel.Text = $"State: {Battery.State}";
            powerSourceLabel.Text = $"Power Source: {Battery.PowerSource}";
        }

        private void GetEnergySaverStatus()
        {
            energySaverStatusLabel.Text = $"Energy Saver: {Battery.EnergySaverStatus}";
        }

        void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            GetBatteryInfo();
        }

        void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
        {
            GetEnergySaverStatus();
        }

    }
}
