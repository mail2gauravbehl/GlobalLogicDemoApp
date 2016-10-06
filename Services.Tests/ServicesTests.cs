using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GlobalLogicDemoApp.Host;
using GlobalLogigDemoApp.Services;
using Moq;
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

    [TestFixture]
    public class MainViewModelTests
    {
        [Test]
        public void Test()
        {
            Mock<IPostsRepository> repMock = new Mock<IPostsRepository>();
            repMock.Setup(a => a.GetPosts()).ReturnsAsync(new List<Post>() { new Post() {Body = "body", Id = "1", Title = "title", UserId = "userid"}});
            var mainViewModel = new  MainViewModel(repMock.Object);
            mainViewModel.PostsCommand.ExecuteAsync(null);
            repMock.Verify(mock => mock.GetPosts(), Times.Exactly(1));
        }
    }
}
