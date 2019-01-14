using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class ConnectivityPage : ContentPage
    {
        public ConnectivityPage()
        {
            InitializeComponent();

            GetConnectivity();
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        private void GetConnectivity()
        {
            networkAccessLabel.Text = $"Network: {Connectivity.NetworkAccess}";
            foreach (var connection in Connectivity.ConnectionProfiles)
            {
                connectionProfilesLabel.Text += $"{connection}\n";
            }
        }

        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            GetConnectivity();
        }

    }
}
