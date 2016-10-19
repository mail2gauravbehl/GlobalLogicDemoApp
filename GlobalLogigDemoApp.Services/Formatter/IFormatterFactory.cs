using GlobalLogigDemoApp.Services.Enums;

namespace GlobalLogigDemoApp.Services.Formatter
{
    public interface IFormatterFactory
    {
        IObjectFormatter GetFormatter(FormatEnum formatEnum);
    }
}