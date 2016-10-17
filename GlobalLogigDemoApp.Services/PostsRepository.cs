using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GlobalLogigDemoApp.Services
{
    public class PostsRepository : IPostsRepository
    {
        LoggerWrapper logger = new LoggerWrapper(typeof(PostsRepository));

        public async Task<IEnumerable<Post>> GetPosts()
        {
            List<Post> posts = new List<Post>();

            try
            {
                var httpClient = new HttpClient();
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("http://jsonplaceholder.typicode.com/posts");

                string stringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
                dynamic postsCollection = JArray.Parse(stringAsync);
               
                foreach (var jsonPost in postsCollection)
                {
                    var post = new Post() { Id = jsonPost.id, UserId = jsonPost.userId, Title = jsonPost.title, Body = jsonPost.body };
                    posts.Add(post);
                }

                return posts;
            }
            catch (HttpRequestException exception)
            {
                logger.LogError(exception.Message, exception);
                throw new PostsRepositoryException("Some Error has occured connecting to the Posts feed. Please try after sometime.");
            }
            catch (Exception genericException)
            {
                logger.LogError(genericException.Message, genericException);

                throw new PostsRepositoryException("Some Error has occured connecting to the Posts feed. Please try after sometime.");
            }
        }
    }

    public class PostsRepositoryException : Exception
    {
        public PostsRepositoryException(string message) : base(message)
        {
        }
    }
}
