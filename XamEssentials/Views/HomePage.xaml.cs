using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamEssentials.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            menuListView.ItemTapped += MenuListView_ItemTapped;

            menuListView.ItemsSource = GetMenu();
        }

        async void MenuListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var menu = e.Item as Menu;

            var page = (Page)Activator.CreateInstance(menu.PageType);
            await Navigation.PushAsync(page);

            menuListView.SelectedItem = null; 
        }

        public List<Menu> GetMenu()
        {
            return new List<Menu>
            {
                new Menu(
                    "⚙️",
                    "Preferences",
                    typeof(PreferencesPage),
                    "Quickly and easily add persistent preferences."),
                new Menu(
                    "🔒",
                    "Secure Storage",
                    typeof(SecureStoragePage),
                    "Securely store data."),
                new Menu(
                    "📱",
                    "Device Info",
                    typeof(DeviceInfoPage),
                    "Find out about the device with ease."),
                new Menu(
                    "📦",
                    "App Info",
                    typeof(AppInfoPage),
                    "Find out about the app with ease."),
                new Menu(
                    "📶",
                    "Connectivity",
                    typeof(ConnectivityPage),
                    "Check connectivity state and detect changes."),
                new Menu(
                    "🔊",
                    "Text To Speech",
                    typeof(TextToSpeechPage),
                    "Vocalize text on the device."),
                new Menu(
                    "📋",
                    "Clipboard",
                    typeof(ClipboardPage),
                    "Quickly and easily use the clipboard."),
                new Menu(
                    "🔋",
                    "Battery",
                    typeof(BatteryPage),
                    "Easily detect battery level, source, and state."),
                new Menu(
                    "🔦",
                    "Flashlight",
                    typeof(FlashlightPage),
                    "A simple way to turn the flashlight on/off."),
                new Menu(
                    "💤",
                    "Keep Screen On",
                    typeof(KeepScreenOnPage),
                    "Keep the device screen awake."),
                new Menu(
                    "📍",
                    "Geolocation",
                    typeof(GeolocationPage),
                    "Quickly get the current location."),
                new Menu(
                    "📍",
                    "Geocoding",
                    typeof(GeocodingPage),
                    "Easily geocode and reverse geocoding."),
                new Menu(
                    "📍",
                    "Launch Maps",
                    typeof(MapsPage),
                    "Easily launch maps with coordinates."),






                new Menu(
                    "📞",
                    "Phone Dialer",
                    typeof(PhoneDialerPage),
                    "Easily open the phone dialer."),
                new Menu(
                    "💬",
                    "SMS",
                    typeof(SMSPage),
                    "Easily send SMS messages."),
                new Menu(
                    "📧",
                    "Email",
                    typeof(EmailPage),
                    "Easily send email messages."),
                new Menu(
                    "🌐",
                    "Browser",
                    typeof(BrowserPage),
                    "Quickly and easily open a browser to a specific website."),
                new Menu(
                    "📁",
                    "File System",
                    typeof(FileSystemPage),
                    "Easily save files to app data."),
                new Menu(
                    "📲",
                    "Share",
                    typeof(SharePage),
                    "Send text and website uris to other apps."),
                new Menu(
                    "📏",
                    "Launcher",
                    typeof(LauncherPage),
                    "Launch other apps via Uri"),
                new Menu(
                    "📏",
                    "Accelerometer",
                    typeof(AccelerometerPage),
                    "Retrieve acceleration data of the device in 3D space."),
                new Menu(
                    "📏",
                    "Compass",
                    typeof(CompassPage),
                    "Monitor compass for changes."),
                new Menu(
                    "📏",
                    "Gyroscope",
                    typeof(GyroscopePage),
                    "Retrieve rotation around the device's three primary axes."),
                new Menu(
                    "📏",
                    "Magnetometer",
                    typeof(MagnetometerPage),
                    "Detect device's orientation relative to Earth's magnetic field."),
                new Menu(
                    "📏",
                    "Orientation Sensor",
                    typeof(OrientationSensorPage),
                    "Retrieve orientation of the device in 3D space."),
                new Menu(
                    "📏",
                    "Barometer",
                    typeof(BarometerPage),
                    "Easily detect pressure level, via the device barometer."),
                new Menu(
                    "📳",
                    "Vibration",
                    typeof(VibrationPage),
                    "Quickly and easily make the device vibrate."),
            };
        }
    }

    public class Menu
    {
        public Menu(string icon, string name, Type pageType, string description)
        {
            Icon = icon;
            Name = name;
            Description = description;
            PageType = pageType;
        }

        public string Icon { get; }

        public string Name { get; }

        public string Description { get; }

        public Type PageType { get; }
    }
}
