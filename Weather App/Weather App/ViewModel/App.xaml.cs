using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather_App.View;
using Config = Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Application = Xamarin.Forms.Application;
using TabbedPage = Xamarin.Forms.TabbedPage;
using Weather_App.Model;

namespace Weather_App.ViewModel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Device.SetFlags(new[] { "MediaElement_Experimental", "Brush_Experimental", "AppTheme_Experimental" });
            TabbedPage tabbedPage = new TabbedPage();

            //tabbedPage.On<Config.Windows>().SetToolbarPlacement(Config.WindowsSpecific.ToolbarPlacement.Bottom);

            //tabbedPage.On<Config.Android>().SetToolbarPlacement(Config.AndroidSpecific.ToolbarPlacement.Bottom);

            tabbedPage.Children.Add(new MainPage());
            tabbedPage.Children.Add(new LocationPage());
            tabbedPage.Children.Add(new CityListPage());
            tabbedPage.Children.Add(new SettingsPage());


            MainPage = tabbedPage;
            
            tabbedPage.BindingContext = tabbedPage.Children[0].BindingContext;
            Binding binding = new Binding("CurrentWeather.WeatherColor");
            binding.Mode = BindingMode.TwoWay;
            binding.Source = tabbedPage.BindingContext;
            tabbedPage.SetBinding(TabbedPage.BarBackgroundColorProperty, binding);


            tabbedPage.Children[1].BindingContext = tabbedPage.Children[0].BindingContext;
            tabbedPage.Children[2].BindingContext = tabbedPage.Children[0].BindingContext;
            tabbedPage.Children[3].BindingContext = tabbedPage.Children[0].BindingContext;
        }

        protected override void OnStart()
        {
        }

        protected async override void OnSleep()
        {
           await Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
        }
    }
}
