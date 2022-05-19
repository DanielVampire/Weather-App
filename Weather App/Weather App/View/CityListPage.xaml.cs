using System;
using System.Threading.Tasks;
using Weather_App.Model;
using Weather_App.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CityListPage : ContentPage
    {
        public CityListPage()
        {
            InitializeComponent();
            
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            GetCity();
        }

        private async void GetCity()
        {
            string city = await DisplayPromptAsync("Добавить город", "Введите название города", "Ok", "Отмена");
            if (city == null)
                return;
            string res = "";
            if(Device.RuntimePlatform == Device.UWP)
                res = ((MainViewModel)BindingContext).GetWeatherUWP(city);
            else
                res = await ((MainViewModel)BindingContext).GetWeather(city);
            if (res != "true")
                await DisplayAlert("Error", res, "Ok");
            TabbedPage tab = (this.Parent as TabbedPage);
            await Task.Delay(400);
            tab.CurrentPage = tab.Children[0];
            tab.SelectedItem = tab.Children[0];
        }

        private async void ViewCell_Tapped(object sender, EventArgs e)
        {
            ViewCell text = sender as ViewCell;
            TabbedPage tab = (this.Parent as TabbedPage);
            if (Device.RuntimePlatform == Device.UWP)
                ((MainViewModel)BindingContext).GetWeatherUWP((text.BindingContext as Weather).City);
            else
                await ((MainViewModel)BindingContext).GetWeather((text.BindingContext as Weather).City);
            await Task.Delay(400);
            tab.CurrentPage = tab.Children[0];
            tab.SelectedItem = tab.Children[0];
        }

        async void refreshButton_Clicked(object sender, EventArgs e)
        {
            await Task.WhenAll(
                refreshButton.RelRotateTo(-360, 1000),
                this.FadeTo(0, 1000),
                (this.Parent as TabbedPage).FadeTo(0, 1000)
                );
            (BindingContext as MainViewModel).RefreshCitysUWP.Execute(sender);
            await Task.Delay(250);
            await Task.WhenAll(
                refreshButton.RelRotateTo(-360, 1000),
                this.FadeTo(1, 1000),
                (this.Parent as TabbedPage).FadeTo(1, 1000)
                );
        }

        async void ListView_Refreshing(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).IsLoading = true;
            await Task.WhenAll(
                this.FadeTo(0, 500),
                (this.Parent as TabbedPage).FadeTo(0, 500)
                );
            (BindingContext as MainViewModel).IsLoading = false;
            await Task.Delay(250);
            await Task.WhenAll(
                this.FadeTo(1, 500),
                (this.Parent as TabbedPage).FadeTo(1, 500)
                );
        }
    }
}