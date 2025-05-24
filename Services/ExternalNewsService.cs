using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using startup.Models;
using startup.Services;

public class ExternalNewsService : IExternalNewsService
{
    private readonly HttpClient _httpClient;

    public ExternalNewsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Post>> GetPostsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return await _httpClient.GetFromJsonAsync<User>($"https://jsonplaceholder.typicode.com/users/{userId}");
    }

    public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        return await _httpClient.GetFromJsonAsync<List<Comment>>($"https://jsonplaceholder.typicode.com/comments?postId={postId}");
    }
}