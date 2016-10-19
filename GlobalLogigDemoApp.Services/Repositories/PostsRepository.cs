using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GlobalLogigDemoApp.Services.Domain;
using Newtonsoft.Json.Linq;

namespace GlobalLogigDemoApp.Services.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        readonly LoggerWrapper _logger = new LoggerWrapper(typeof(PostsRepository));

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
                _logger.LogError(exception.Message, exception);
                throw new PostsRepositoryException("Some Error has occured connecting to the Posts feed. Please try after sometime.");
            }
            catch (Exception genericException)
            {
                _logger.LogError(genericException.Message, genericException);

                throw new PostsRepositoryException("Some Error has occured connecting to the Posts feed. Please try after sometime.");
            }
        }
    }

    public class CommentsRepository : ICommentsRepository
    {
        readonly LoggerWrapper _logger = new LoggerWrapper(typeof(CommentsRepository));

        public async Task<IEnumerable<Comment>> GetComments (string postId)
        {

            List<Comment> comments = new List<Comment>();

            try
            {
                var httpClient = new HttpClient();
                string requestUri = string.Format("http://jsonplaceholder.typicode.com/comments?postId={0}", postId);
                HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(requestUri);

                string stringAsync = await httpResponseMessage.Content.ReadAsStringAsync();
                dynamic commentsCollection = JArray.Parse(stringAsync);

                foreach (var jsonPost in commentsCollection)
                {
                    var post = new Comment() { PostId = jsonPost.postId, Id = jsonPost.id, Name = jsonPost.name, Email = jsonPost.email, Body = jsonPost.body };
                    comments.Add(post);
                }

                return comments;
            }
            catch (HttpRequestException exception)
            {
                _logger.LogError(exception.Message, exception);
                throw new PostsRepositoryException("Some Error has occured connecting to the Comments feed. Please try after sometime.");
            }
            catch (Exception genericException)
            {
                _logger.LogError(genericException.Message, genericException);

                throw new PostsRepositoryException("Some Error has occured connecting to the Comments feed. Please try after sometime.");
            }
        }
    }

}
