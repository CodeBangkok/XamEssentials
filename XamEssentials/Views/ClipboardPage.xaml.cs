using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class ClipboardPage : ContentPage
    {
        public ClipboardPage()
        {
            InitializeComponent();

            copyButton.Clicked += CopyButton_Clicked;
            pasteButton.Clicked += PasteButton_Clicked;
        }

        async void CopyButton_Clicked(object sender, EventArgs e) => await Clipboard.SetTextAsync(fieldValueEntry.Text);

        async void PasteButton_Clicked(object sender, EventArgs e)
        {
            if (Clipboard.HasText)
            {
                fieldValueEntry.Text = await Clipboard.GetTextAsync();
            }
        }

    }
}
