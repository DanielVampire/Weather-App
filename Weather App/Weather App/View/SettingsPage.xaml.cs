using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_App.Model;
using Xamarin.CommunityToolkit.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        OSAppTheme theme = Application.Current.UserAppTheme;
        public SettingsPage()
        {
            InitializeComponent();
            if (theme == OSAppTheme.Dark)
                DarkTheme.Value = true;
            else
                LightTheme.Value = true;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            if (Application.Current.UserAppTheme == OSAppTheme.Light)
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            else
                Application.Current.UserAppTheme = OSAppTheme.Light;
        }

        private void DarkTheme_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                LightTheme.Value = false;
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
            else
                Application.Current.UserAppTheme = OSAppTheme.Light;
        }

        private void LightTheme_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                DarkTheme.Value = false;
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
                Application.Current.UserAppTheme = OSAppTheme.Dark;
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {

        }
    }
}