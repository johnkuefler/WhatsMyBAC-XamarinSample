using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SampleWhatsMyBAC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWhatsMyBAC
{
    public class Settings
    {
        private const string personJson = "";
        private static readonly string personJsonDefault = string.Empty;

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static Person PersonData
        {
            get
            {
                string data = AppSettings.GetValueOrDefault(personJson, personJsonDefault);
                if (String.IsNullOrEmpty(data))
                {
                    return null;
                }
                else
                {
                    return JsonConvert.DeserializeObject<Person>(data);
                }
            }
            set
            {
                string data = JsonConvert.SerializeObject(value);
                AppSettings.AddOrUpdateValue(personJson, data);
            }
        }
    }
}
