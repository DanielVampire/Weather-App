using Xamarin.Essentials;

namespace Weather_App.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("x0tqS9EIp3opsYhy043j~k_JxCvdgvBxoHwuo4Op99g~Aj_wLQcFo2vGMcBIa-JWWfyyhT8b2yUh_WFTQxSPW_hGJnpOpKmeXkexywVS5C7g");
            Platform.MapServiceToken = "x0tqS9EIp3opsYhy043j~k_JxCvdgvBxoHwuo4Op99g~Aj_wLQcFo2vGMcBIa-JWWfyyhT8b2yUh_WFTQxSPW_hGJnpOpKmeXkexywVS5C7g";
            LoadApplication(new ViewModel.App());
        }
    }
}
