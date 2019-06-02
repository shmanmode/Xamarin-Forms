using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Messaging;
using System.Text.RegularExpressions;
using Basic.Models;

namespace Basic
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SmsButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var MObNo = entry_no.Text;
                var mobileNoPattern = @"^[+1-9][0-9]{12}$";

                if (Regex.IsMatch((entry_no.Text), mobileNoPattern))
                {
                    var PhoneCall = CrossMessaging.Current.PhoneDialer;

                    if (PhoneCall.CanMakePhoneCall)
                    {
                        Device.OpenUri(new Uri("tel:" + MObNo));
                        // PhoneCall.MakePhoneCall(MObNo);
                    }
                }
                else
                {
                    // await DisplayAlert("Hey", "Enter correct mobile No.", "OK");
                    MobileError _mobileerroe = new MobileError();
                    _mobileerroe.lblError = "Mobile No not Valid";
                    BindingContext = _mobileerroe;
                }
            }
            catch
            {
                //await DisplayAlert("Hey", "Enter mobile No.", "OK");
                MobileError _mobileerror = new MobileError();
                _mobileerror.lblError = "Mobile No not Valid";
                BindingContext = _mobileerror;
            }
        }

        private void entry_no_TextChanged(object sender, TextChangedEventArgs e)
        {
            string _text = entry_no.Text;
            if (_text.Length > 13)
            {
                _text = _text.Remove(_text.Length - 1);
                entry_no.Text = _text;
            }
        }
    }
}
