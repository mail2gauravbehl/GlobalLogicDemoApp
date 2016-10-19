using System.Collections.Generic;
using System.Text;
using GlobalLogigDemoApp.Services.Domain;

namespace GlobalLogigDemoApp.Services.Formatter
{
    public class StringFormatter : IObjectFormatter
    {
        public string Convert(IEnumerable<Comment> comments)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var comment in comments)
            {
                sb.AppendFormat(string.Format("Post id: {0}, Comment Id: {1}, Name: {2}, Email: {3}, Body: {4}",
                    comment.PostId, comment.Id, comment.Name, comment.Email, comment.Body));
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}