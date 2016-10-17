using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalLogigDemoApp.Services;
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
    }
}
