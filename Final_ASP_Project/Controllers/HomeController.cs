using Final_ASP_Project.Data;
using Final_ASP_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Final_ASP_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()    
        {
            return View();
        }

        public IActionResult ShowBookUser()
        {
            IEnumerable<Book> book = _db.books.Include(b => b.genre).ToList();
            return View(book);

        }
        public async Task<IActionResult> ShowBookUserDetail(int? id)
        {
            if (id == null || _db.books == null)
            {
                return NotFound();
            }

            var book = await _db.books
                .Include(b => b.genre)
                .FirstOrDefaultAsync(m => m.book_Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}