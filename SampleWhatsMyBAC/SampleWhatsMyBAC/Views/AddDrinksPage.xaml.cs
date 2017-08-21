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
    public partial class AddDrinksPage : ContentPage
    {
        public AddDrinksPage()
        {
            InitializeComponent();
            this.drinksPicker.ItemsSource = GlobalConfig.DrinksMasterList.Select(x=>x.Name).ToList();
        }

        private void saveButton_Clicked(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(quantityEntry.Text);
            for (int i = 0; i < quantity; i++)
            {
                GlobalConfig.ActiveDrinksList.Add(GlobalConfig.DrinksMasterList.Where(rec => rec.Name == drinksPicker.Items[drinksPicker.SelectedIndex]).FirstOrDefault());
            }
            Navigation.PushAsync(new MainPage());
        }
    }
}