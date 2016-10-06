using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GlobalLogigDemoApp.Services;
using Newtonsoft.Json.Linq;
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
