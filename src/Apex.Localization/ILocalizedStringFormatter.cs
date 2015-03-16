namespace Apex.Localization
{
	public interface ILocalizedStringFormatter
	{
		string Format(string format, params object[] arguments);
	}
}