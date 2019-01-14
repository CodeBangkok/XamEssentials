using System;
using System.Collections.Generic;
using Xamarin.Essentials;

using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class AppInfoPage : ContentPage
    {
        public AppInfoPage()
        {
            InitializeComponent();

            nameLabel.Text = $"Name: {AppInfo.Name}";
            packageName.Text = $"Package: {AppInfo.PackageName}";
            versionLabel.Text = $"Version: {AppInfo.Version}";
            buildLabel.Text = $"Build: {AppInfo.BuildString}";

            settingButton.Clicked += SettingButton_Clicked;
        }

        void SettingButton_Clicked(object sender, EventArgs e)
        {
            AppInfo.ShowSettingsUI();
        }

    }
}
