using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWhatsMyBAC.Models
{
    public class Person
    {
        public string Gender { get; set; }
        public float Weight { get; set; }


        public float CalculateBAC(List<Drink> drinks, float timePassed)
        {
            float output = 0;

            float r = 0.68f;
            if (Gender.ToString() == "Female")
            {
                r = 0.55f;
            }

            output = (((drinks.Count * 0.06f * 100f * 1.055f) / (Weight * r)) - (0.015f * timePassed)) / 2;

            if (output < 0)
            {
                output = 0;
            }

            return output;
        }
    }
}
