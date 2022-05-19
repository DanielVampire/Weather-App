using System;
using Weather_App.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather_App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            InitializeComponent();
            //GetCurrentLocation();
        }

        //async void GetCurrentLocation()
        //{
        //    try
        //    {
        //        var request = new GeolocationRequest(GeolocationAccuracy.Low, TimeSpan.FromSeconds(10));
        //        CancellationTokenSource cts = new CancellationTokenSource();
        //        var location = await Geolocation.GetLocationAsync(request, cts.Token);
        //        var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

        //        var placemark = placemarks?.FirstOrDefault();
        //        if (placemark != null)
        //        {
        //            var geocodeAddress =
        //                $"AdminArea:       {placemark.AdminArea}\n" +
        //                $"CountryCode:     {placemark.CountryCode}\n" +
        //                $"CountryName:     {placemark.CountryName}\n" +
        //                $"FeatureName:     {placemark.FeatureName}\n" +
        //                $"Locality:        {placemark.Locality}\n" +
        //                $"PostalCode:      {placemark.PostalCode}\n" +
        //                $"SubAdminArea:    {placemark.SubAdminArea}\n" +
        //                $"SubLocality:     {placemark.SubLocality}\n" +
        //                $"SubThoroughfare: {placemark.SubThoroughfare}\n" +
        //                $"Thoroughfare:    {placemark.Thoroughfare}\n";

        //            Console.WriteLine(geocodeAddress);
        //        }
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Handle not supported on device exception
        //    }
        //    catch (FeatureNotEnabledException fneEx)
        //    {
        //        // Handle not enabled on device exception
        //    }
        //    catch (PermissionException pEx)
        //    {
        //        // Handle permission exception
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //    }
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await ((MainViewModel)BindingContext).GetLocation();
            TabbedPage tab = (this.Parent as TabbedPage);
            tab.CurrentPage = tab.Children[0];
            //await DisplayAlert("Получение погоды по местоположению прошло успешно!", 
            //    String.Format("Ваш город: {0}\nПоказатели погоды отобразились на главном экране", 
            //    ((MainViewModel)BindingContext).CurrentWeather.City),
            //    "Ok");
        }
    }
}