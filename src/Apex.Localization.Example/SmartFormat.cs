using SmartFormat;

namespace Apex.Localization.Example
{
    public class SmartFormatter : ILocalizedStringFormatter
    {
        public string Format(string format, params object[] arguments)
        {
            return Smart.Format(format, arguments);
        }
    }
}