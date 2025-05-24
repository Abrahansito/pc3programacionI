using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace startup.Services
{
    public class PostService
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

    }

    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();
    }

    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var posts = await _httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
            return posts ?? new List<Post>();
        }
    }
}