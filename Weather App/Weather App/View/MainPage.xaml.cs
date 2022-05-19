using System;
using System.Threading.Tasks;
using Weather_App.Model;
using Xamarin.Forms;

namespace Weather_App.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
            //Task.Run(AnimateBachground);
        }

        //private async void AnimateBachground()
        //{
        //    Action<double> forward = input => gradient.AnchorY = input;
        //    Action<double> backward = input => gradient.AnchorY = input;
        //    while(true)
        //    {
        //        gradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 4000, easing: Easing.SinIn);
        //        await Task.Delay(5000);
        //        gradient.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 4000, easing: Easing.SinIn);
        //        await Task.Delay(5000);
        //    }
        //}
        async void refreshButton_Clicked(object sender, EventArgs e)
        {
            await Task.WhenAll(
                refreshButton.RelRotateTo(-360, 1000),
                this.FadeTo(0, 1000),
                (this.Parent as TabbedPage).FadeTo(0, 1000)
                );
            (BindingContext as MainViewModel).RefreshCurrentUWP.Execute(sender);
            await Task.Delay(250);
            await Task.WhenAll(
                refreshButton.RelRotateTo(-360, 1000),
                this.FadeTo(1, 1000),
                (this.Parent as TabbedPage).FadeTo(1, 1000)
                );
        }

        async void ForecastList_Refreshing(object sender, EventArgs e)
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

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            LinearGradientBrush linear = new LinearGradientBrush();
            linear.StartPoint = new Point(1, 0);
            linear.EndPoint = new Point(1, 1);
            linear.GradientStops.Add(new GradientStop(Color.Transparent, 0f));
            linear.GradientStops.Add(new GradientStop((BindingContext as MainViewModel).CurrentWeather.WeatherColor, 1f));
            gradient.Background = linear;
        }

    }
}
