using Microsoft.AspNetCore.Mvc;
using startup.Data;
using startup.Models;
using Microsoft.EntityFrameworkCore;

namespace startup.Controllers
{
    [Route("api/[controller]")]
    public class FeedbackController : Controller
    {
        private readonly ILogger<FeedbackController> _logger;
        private readonly ApplicationDbContext _context;

        public FeedbackController(ILogger<FeedbackController> logger, ApplicationDbContext context)
        {
            _context = context;
             _logger = logger; 
           
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var feedbacks = await _context.Feedbacks.ToListAsync();
            return Ok(feedbacks);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Feedback feedback)
        {
            // Validar si ya votó por este post
            var yaExiste = await _context.Feedbacks
                .AnyAsync(f => f.PostId == feedback.PostId);

            if (yaExiste)
                return BadRequest("Ya existe un feedback para este post.");

            feedback.Fecha = DateTime.UtcNow;

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return Ok(feedback);
        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}