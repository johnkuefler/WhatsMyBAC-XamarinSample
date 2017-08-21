using SampleWhatsMyBAC.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWhatsMyBAC
{
    public static class GlobalConfig
    {
        public static ObservableCollection<Drink> ActiveDrinksList = new ObservableCollection<Drink>();

        public static List<Drink> DrinksMasterList = new List<Drink>(
            new Drink[] {
                new Drink("Beer",0.05f,12f,""),
                new Drink("Wine",0.12f,5,""),
                new Drink("Cocktail",0.40f,1.25f,"")
            }
        );

        public static Drink GetDrinkByName(string name)
        {
            return DrinksMasterList.Where(rec => rec.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }
    }
}
