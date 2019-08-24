using Plugin.DeviceInfo;
using Xamarin.Forms;

namespace DeviceInfo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
            getDeviceInfo();
        }

        private void getDeviceInfo()
        {
            Id.Text = CrossDeviceInfo.Current.Id;

            Idi.Text = CrossDeviceInfo.Current.Idiom.ToString();

            Mdl.Text = CrossDeviceInfo.Current.Model;

            PLF.Text = CrossDeviceInfo.Current.Platform.ToString();

            Vs.Text = CrossDeviceInfo.Current.Version;
        }
    }
}