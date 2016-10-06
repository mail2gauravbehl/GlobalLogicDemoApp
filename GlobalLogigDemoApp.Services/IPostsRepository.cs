using System.Collections.Generic;
using System.Threading.Tasks;

namespace GlobalLogigDemoApp.Services
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }
}