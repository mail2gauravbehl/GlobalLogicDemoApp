using System.Collections.Generic;
using GlobalLogigDemoApp.Services.Domain;

namespace GlobalLogigDemoApp.Services.Formatter
{
    public class JsonFormatter : IObjectFormatter
    {
        public string Convert(IEnumerable<Comment> comments)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(comments);
        }
    }
}