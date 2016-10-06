using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GlobalLogigDemoApp.Services
{
    public class PostsRepository : IPostsRepository
    {
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
                throw;
            }
            catch (Exception genericException)
            {
                throw;
            }

            return posts;
        }


    }

    public class Post
    {
        public string UserId { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}
