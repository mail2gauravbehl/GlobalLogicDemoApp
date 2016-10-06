using System.Collections.Generic;
using GlobalLogicDemoApp.Host;
using GlobalLogigDemoApp.Services;
using Moq;
using NUnit.Framework;

namespace Services.Tests
{
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