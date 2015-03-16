using Jeffijoe.MessageFormat;
using System;
using System.Collections.Generic;

namespace Apex.Localization.Example
{
    public class MessageFormat : ILocalizedStringFormatter
    {
        MessageFormatter formatter;

        public MessageFormat()
        {
            this.formatter = new MessageFormatter();
        }

        public string Format(string format, params object[] arguments)
        {
            if (arguments.Length > 2)
            {
                throw new ArgumentException("This method must not be invoked with more than 2 arguments.");
            }

            if (arguments[0].GetType() == typeof(Dictionary<string, object>))
            {
                return this.formatter.FormatMessage(format, (Dictionary<string, object>)arguments[0]);
            }

            return this.formatter.FormatMessage(format, arguments[0]);
        }
    }
}