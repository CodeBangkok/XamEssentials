using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class BrowserPage : ContentPage
    {
        public BrowserPage()
        {
            InitializeComponent();

            openButton.Clicked += OpenButton_Clicked;

            browserLaunchModesPicker.ItemsSource = Enum.GetNames(typeof(BrowserLaunchMode));
        }

        async void OpenButton_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(uriEntry.Text, (BrowserLaunchMode)browserLaunchModesPicker.SelectedIndex);
        }

    }
}
