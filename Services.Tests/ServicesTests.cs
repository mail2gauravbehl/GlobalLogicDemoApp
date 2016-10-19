using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalLogigDemoApp.Services;
using GlobalLogigDemoApp.Services.Domain;
using GlobalLogigDemoApp.Services.Repositories;
using NUnit.Framework;

namespace Services.Tests
{
    [TestFixture]
    public class ServicesTests
    {
        [Test]
        public void When_Get_Posts_Is_Called_It_Returns_All_Posts()
        {
           IPostsRepository postsRepository = new PostsRepository();
            Task<IEnumerable<Post>> posts =  postsRepository.GetPosts();
            var postsResult = posts.Result;

            Assert.IsNotNull(postsResult);
        } 
        
        [Test]
        public void When_Comments_Is_Called_It_Returns_One_Comment()
        {
            ICommentsRepository commentRepository = new CommentsRepository();
            Task<IEnumerable<Comment>> comments = commentRepository.GetComments("1");
            var commentsResult = comments.Result;

            Assert.IsNotNull(commentsResult);
        }
    }
}
