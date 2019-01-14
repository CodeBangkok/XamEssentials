using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class SecureStoragePage : ContentPage
    {
        public SecureStoragePage()
        {
            InitializeComponent();

            loadButton.Clicked += LoadButton_Clicked;
            saveButton.Clicked += SaveButton_Clicked;
            removeButton.Clicked += RemoveButton_Clicked;
            removeAllButton.Clicked += RemoveAllButton_Clicked;
        }

        async void LoadButton_Clicked(object sender, EventArgs e)
        {
            valueEntry.Text = await Xamarin.Essentials.SecureStorage.GetAsync(keyEntry.Text);
        }

        async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync(keyEntry.Text, valueEntry.Text);
        }

        void RemoveButton_Clicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.Remove(keyEntry.Text);
        }

        void RemoveAllButton_Clicked(object sender, EventArgs e)
        {
            Xamarin.Essentials.SecureStorage.RemoveAll();
        }

    }
}
