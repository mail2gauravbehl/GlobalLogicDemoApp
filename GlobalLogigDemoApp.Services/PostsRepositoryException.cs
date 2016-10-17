using System;

namespace GlobalLogigDemoApp.Services
{
    public class PostsRepositoryException : Exception
    {
        public PostsRepositoryException(string message) : base(message)
        {
        }
    }
}