using System.Globalization;

namespace Apex.Localization
{
    public interface ILocalizedStringProvider
    {
        string GetString(string name, CultureInfo culture);

        string GetString(string name, CultureInfo culture, string textDomain);
    }
}