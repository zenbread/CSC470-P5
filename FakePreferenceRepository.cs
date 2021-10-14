using System.Collections.Generic;

namespace P5
{
    class FakePreferenceRepository : IPreferenceRepository
    {
        public const string PREFERENCE_PROJECT_ID = "Project_Id";
        public const string PREFERENCE_PROJECT_NAME = "Project_Name";
        private const string NO_ERROR = "";
        private static Dictionary<string, Dictionary<string, string>> preferences = new Dictionary<string, Dictionary<string, string>>();
        string IPreferenceRepository.GetPreference(string UserName, string PreferenceName)
        {
            Dictionary<string, string> NameValuePair;
            string value = "";
            if (preferences.TryGetValue(UserName, out NameValuePair))
            {
                NameValuePair.TryGetValue(PreferenceName, out value);
            }
            return value;
        }

        string IPreferenceRepository.SetPreference(string UserName, string PreferenceName, string Value)
        {
            Dictionary<string, string> NameValuePair;
            if (!preferences.TryGetValue(UserName, out NameValuePair))
            {
                NameValuePair.Add(PreferenceName, Value);
                preferences.Add(UserName, NameValuePair);
                return NO_ERROR;
            }
            NameValuePair = new Dictionary<string, string>
            {
                { PreferenceName, Value }
            };
            preferences.Add(UserName, NameValuePair);
            return NO_ERROR;
        }
    }
}
