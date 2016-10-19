using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalLogigDemoApp.Services.Domain;

namespace GlobalLogigDemoApp.Services.Repositories
{
    public interface IPostsRepository
    {
        Task<IEnumerable<Post>> GetPosts();
    }  
    
    public interface ICommentsRepository
    {
        Task<IEnumerable<Comment>> GetComments(string postId);
    }
}