using System.Collections.Generic;
using GlobalLogigDemoApp.Services.Domain;

namespace GlobalLogigDemoApp.Services.Formatter
{
    public interface IObjectFormatter
    {
        string Convert(IEnumerable<Comment> comments);
    }
}