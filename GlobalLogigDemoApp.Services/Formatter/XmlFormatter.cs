using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using GlobalLogigDemoApp.Services.Domain;

namespace GlobalLogigDemoApp.Services.Formatter
{
    public class XmlFormatter : IObjectFormatter
    {
        public string Convert(IEnumerable<Comment> comments)
        {
            try
            {
                var xEle = new XElement("Comments",
                    from comment in comments
                    select new XElement("Comment",
                        new XAttribute("ID", comment.Id),
                        new XAttribute("PostId", comment.PostId),
                        new XElement("Name", comment.Name),
                        new XElement("Email", comment.Email),
                        new XElement("Body", comment.Body)
                              
                    ));
                return xEle.ToString();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}