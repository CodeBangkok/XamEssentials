using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class FileSystemPage : ContentPage
    {
        string filePath = Path.Combine(FileSystem.AppDataDirectory, "hello.txt");

        public FileSystemPage()
        {
            InitializeComponent();

            loadButton.Clicked += LoadButton_Clicked;
            saveButton.Clicked += SaveButton_Clicked;
            deleteButton.Clicked += DeleteButton_Clicked;
        }

        void LoadButton_Clicked(object sender, EventArgs e)
        {
            currentContentsEditor.Text = File.ReadAllText(filePath);
        }

        void SaveButton_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(filePath, currentContentsEditor.Text);
        }

        void DeleteButton_Clicked(object sender, EventArgs e)
        {
            File.Delete(filePath);
        }

    }
}
