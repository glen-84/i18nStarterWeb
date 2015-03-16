using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Framework.Localization;

namespace Apex.Localization
{
    public class StringLocalizer : IStringLocalizer
    {
        private ILocalizedStringProvider provider;
        private ILocalizedStringFormatter formatter;
        private readonly CultureInfo culture;

        public StringLocalizer(ILocalizedStringProvider provider)
        {
            this.provider = provider;
        }

        public StringLocalizer(ILocalizedStringProvider provider, ILocalizedStringFormatter formatter)
        {
            this.provider = provider;
            this.formatter = formatter;
        }

        public StringLocalizer(ILocalizedStringProvider provider, ILocalizedStringFormatter formatter, CultureInfo culture)
        {
            this.provider = provider;
            this.formatter = formatter;
            this.culture = culture;
        }

        public LocalizedString this[string name] => GetString(name);

        public LocalizedString this[string name, params object[] arguments] => GetString(name, arguments);

        public LocalizedString GetString(string name)
        {
            string value = this.provider.GetString(name, culture);

            return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
        }

        public LocalizedString GetString(string name, params object[] arguments)
        {
            string format = this.provider.GetString(name, culture);
            string value;

            if (format == null)
            {
                // TODO: Make this configurable with the ability to use the key ("name").
                value = "[STRING NOT FOUND!!!]";
            }
            else
            {
                // TODO: Handle formatting exceptions.
                if (this.formatter == null)
                {
                    // Use regular string formatting.
                    value = string.Format(format ?? name, arguments);
                }
                else
                {
                    // Use the specified string formatter.
                    value = this.formatter.Format(format, arguments);
                }
            }

            return new LocalizedString(name, value, resourceNotFound: format == null);
        }

        public IEnumerator<LocalizedString> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return new StringLocalizer(provider, formatter, culture);
        }
    }
}