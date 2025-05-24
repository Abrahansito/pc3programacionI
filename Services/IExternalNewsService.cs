using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using startup.Models;
using startup.Services;

namespace startup.Services
{
    public interface IExternalNewsService
    {
        Task<List<Post>> GetPostsAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
    }
}