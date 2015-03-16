using System.Collections.Generic;
using System.Globalization;

namespace Apex.Localization.Example
{
    public class LocalizedStringProvider : ILocalizedStringProvider
    {
		private Dictionary<string, string> strings;

        public LocalizedStringProvider(Dictionary<string, string> strings)
        {
			this.strings = strings;
        }

		public string GetString(string name, CultureInfo culture)
		{
			// TODO: Load localized string from database, CSV, JSON, web service, etc.
			string value;

			if (this.strings.TryGetValue(name, out value))
			{
				return value;
			}

			return null;
		}

		public string GetString(string name, CultureInfo culture, string textDomain)
		{
			// TODO: Load localized string from database, CSV, JSON, web service, etc.
			string value;

			if (this.strings.TryGetValue(name, out value))
			{
				return value;
			}

			return null;
		}
	}
}
