using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class PreferencesPage : ContentPage
    {
        public PreferencesPage()
        {
            InitializeComponent();
            saveButton.Clicked += SaveButton_Clicked;
            removeButton.Clicked += RemoveButton_Clicked;

            textEntry.Text = Xamarin.Essentials.Preferences.Get("Name", string.Empty);
        }

        void SaveButton_Clicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.Preferences.Set("Name", textEntry.Text);
        }

        void RemoveButton_Clicked(object sender, EventArgs e)
        {
            textEntry.Text = "";
            Xamarin.Essentials.Preferences.Remove("Name");
        }

    }
}
