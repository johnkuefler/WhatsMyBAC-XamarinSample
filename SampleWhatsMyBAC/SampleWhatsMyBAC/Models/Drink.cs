using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWhatsMyBAC.Models
{
    public class Drink
    {
        public string Name { get; set; }
        public float AlcoholPercentage { get; set; }
        public float Volume { get; set; }
        public string Icon { get; set; }

        public Drink(string name, float percentage, float volume, string icon)
        {
            this.Name = name;
            this.AlcoholPercentage = percentage;
            this.Volume = volume;
            this.Icon = icon;
        }

        public Drink()
        {

        }
    }
}
