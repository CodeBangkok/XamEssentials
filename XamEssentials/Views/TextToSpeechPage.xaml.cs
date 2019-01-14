using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;

namespace XamEssentials.Views
{
    public partial class TextToSpeechPage : ContentPage
    {
        public TextToSpeechPage()
        {
            InitializeComponent();

            speakButton.Clicked += SpeakButton_Clicked;
            textEditor.Text = "สวัสดีครับ";
        }

        async void SpeakButton_Clicked(object sender, EventArgs e)
        {
            var locales = await TextToSpeech.GetLocalesAsync();
            var locale = locales.FirstOrDefault(l => l.Language == "en" && l.Country == "US");
            var option = new SpeechOptions
            {
                Locale = locale
            };
            await TextToSpeech.SpeakAsync(textEditor.Text, option);
        }

    }
}
