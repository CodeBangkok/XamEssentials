using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class LauncherPage : ContentPage
    {
        public LauncherPage()
        {
            InitializeComponent();

            launchButton.Clicked += LaunchButton_Clicked;
            checkLaunchButton.Clicked += CheckLaunchButton_Clicked;
        }

        async void CheckLaunchButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await Launcher.CanOpenAsync(launchUriEntry.Text);
            if (isOk)
            {
                await DisplayAlert("", "Can be launch", "OK");
            }
            else await DisplayAlert("", "Can not be launch", "OK");
        }


        async void LaunchButton_Clicked(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(launchUriEntry.Text);
        }

    }
}
