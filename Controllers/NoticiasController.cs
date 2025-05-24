using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using startup.Models;
using startup.Services;
using startup.Data;

namespace startup.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ILogger<NoticiasController> _logger;
        private readonly IExternalNewsService _postService;
        private readonly ApplicationDbContext _context;


        public NoticiasController(ILogger<NoticiasController> logger, IExternalNewsService postService, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
            _postService = postService;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetPostsAsync();
            return View(posts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var posts = await _postService.GetPostsAsync();
            var post = posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
                return NotFound();

            var author = await _postService.GetUserByIdAsync(post.UserId);
            var comments = await _postService.GetCommentsByPostIdAsync(id);

            var viewModel = new PostDetailViewModel
            {
                Post = post,
                Author = author,
                Comments = comments
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}
