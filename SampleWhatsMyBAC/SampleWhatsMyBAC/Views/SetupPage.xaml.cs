using SampleWhatsMyBAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleWhatsMyBAC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetupPage : ContentPage
    {
        public SetupPage()
        {
            InitializeComponent();

            if (Settings.PersonData != null)
            {
                this.genderPicker.SelectedIndex = this.genderPicker.Items.IndexOf(Settings.PersonData.Gender);
                this.weightEntry.Text = Settings.PersonData.Weight.ToString();
            }
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(weightEntry.Text) || String.IsNullOrEmpty(Convert.ToString(genderPicker.SelectedItem)))
            {
                DisplayAlert("Error", "Please enter all values", "Ok");
            }

            Person person = new Person();
            person.Gender = genderPicker.SelectedItem.ToString();
            person.Weight = float.Parse(weightEntry.Text);
            Settings.PersonData = person;

            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}