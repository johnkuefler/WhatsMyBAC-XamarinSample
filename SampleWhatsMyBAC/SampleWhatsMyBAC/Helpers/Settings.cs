// Helpers/Settings.cs
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using SampleWhatsMyBAC.Models;

namespace SampleWhatsMyBAC.Helpers
{
    public static class Settings
    {
        private const string UserJson = "";
        private static readonly string UserJsonDefault = string.Empty;

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static Person UserData
        {
            get
            {
                string data = AppSettings.GetValueOrDefault(UserJson, UserJsonDefault);
                if (string.IsNullOrEmpty(data))
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
                AppSettings.AddOrUpdateValue(UserJson, data);
            }
        }
    }
}