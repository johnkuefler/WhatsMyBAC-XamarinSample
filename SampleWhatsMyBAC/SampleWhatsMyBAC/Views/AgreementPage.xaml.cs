using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleWhatsMyBAC.Helpers;

namespace SampleWhatsMyBAC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgreementPage : ContentPage
    {
        public AgreementPage()
        {
            InitializeComponent();
        }

        private void agreeButton_Clicked(object sender, EventArgs e)
        {
            if (Settings.PersonData == null)
            {
                Navigation.PushAsync(new SetupPage());
            }
            else
            {
                Navigation.PushAsync(new MainPage());
            }

        }
    }
}