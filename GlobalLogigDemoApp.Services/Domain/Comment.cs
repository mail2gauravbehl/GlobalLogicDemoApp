using System.Xml.Serialization;

namespace GlobalLogigDemoApp.Services.Domain
{
    public class Comment
    {
        public string PostId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }       
        public string Email { get; set; }
        public string Body { get; set; }
    }
}