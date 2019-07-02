using System.Globalization;
using System.Resources;

namespace TestApp.BL.Controller
{
    public class LanguageFormatter
    {
        ResourceManager ResourceManager;
        CultureInfo Culture;

        public LanguageFormatter(ResourceManager resourceManager, CultureInfo culture)
        {
            ResourceManager = resourceManager;
            Culture = culture;
        }

        public string Text(string value)
        {
            return ResourceManager.GetString(value, Culture);
        }

        public string BuildString(string firstString, string secondString)
        {
            return Text(firstString) + " " + Text(secondString);
        }
    }
}
