using System.Collections.Generic;
using GlobalLogigDemoApp.Services.Enums;

namespace GlobalLogigDemoApp.Services.Formatter
{
    public class FormatterFactory : IFormatterFactory
    {
        private static Dictionary<FormatEnum, IObjectFormatter> _dict = null;

        static FormatterFactory()
        {
            _dict  = new Dictionary<FormatEnum, IObjectFormatter>();
            _dict.Add(FormatEnum.Json, new JsonFormatter());
            _dict.Add(FormatEnum.Text, new StringFormatter());
            _dict.Add(FormatEnum.Xml, new XmlFormatter());
        }

        public IObjectFormatter GetFormatter(FormatEnum formatEnum)
        {
            return _dict[formatEnum];
        }
    }
}