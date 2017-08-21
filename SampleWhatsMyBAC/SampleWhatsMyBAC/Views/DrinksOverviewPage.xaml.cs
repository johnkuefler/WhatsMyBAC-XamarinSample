using SampleWhatsMyBAC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleWhatsMyBAC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrinksOverviewPage : ContentPage
    {
        public DrinksOverviewPage()
        {
            InitializeComponent();
            this.drinksList.ItemsSource = GlobalConfig.ActiveDrinksList.Select(x=>x.Name);
        }

        private void addDrinkButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddDrinksPage());
        }

        private void clearButton_Clicked(object sender, EventArgs e)
        {
            GlobalConfig.ActiveDrinksList = new ObservableCollection<Drink>();
            drinksList.ItemsSource = " ";
            howManyHoursEntry.Text = "";
            resultsLabel.Text = "";
        }

        private void howManyHoursEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            calculateBAC();
        }

        private void calculateBAC()
        {
            float hours = 0;
            bool validHours = float.TryParse(howManyHoursEntry.Text, out hours);
            if (validHours)
            {
                resultsLabel.Text = "Your BAC is: " + Settings.PersonData.CalculateBAC(GlobalConfig.ActiveDrinksList.ToList(), hours);
            }
            else
            {
                resultsLabel.Text = "Please enter a valid number of hours";
            }
        }

        private void drinksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string drinkName = e.SelectedItem as string;
            Drink drink = GlobalConfig.GetDrinkByName(drinkName);
            GlobalConfig.ActiveDrinksList.Remove(drink);
            this.drinksList.ItemsSource = GlobalConfig.ActiveDrinksList.Select(x => x.Name);
            calculateBAC();
        }
    }
}