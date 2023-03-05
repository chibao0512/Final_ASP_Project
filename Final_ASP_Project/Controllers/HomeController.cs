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
        public async Task<IEnumerable<Genre>> Genres()
        {
            return await _db.genres.ToListAsync();
        }

        public IActionResult Index()    
        {
            return View();
        }

        [Route("Home/ShowBook")]
        public async Task<IActionResult> ShowBook(string sterm = "", int genreId = 0)
        {

            IEnumerable<Book> books = await GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _db.genres.ToListAsync();
         
            Models.BookDisplayModel bookModel = new Models.BookDisplayModel
            {
                Books = books,
                Genres = genres,
            };
            return View(bookModel);
        }
        public async Task<IActionResult> BookDetail(int id)
        {
            if (id == null || _db.books == null)
            {
                return NotFound();
            }
            else
            {
                var book = _db.books.Include(x => x.genre).FirstOrDefault(b => b.book_Id == id);
                if (book == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(book);
                }
            }

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IEnumerable<Book>> GetBooks1(string sTerm = "", int genreId = 0)
        {

            IEnumerable<Book> books = await (from book in _db.books
                                             join genre in _db.genres
                                             on book.genre_Id equals genre.genre_Id
                                             where string.IsNullOrWhiteSpace(sTerm) || (book != null && book.book_Title.ToLower().StartsWith(sTerm))
                                             select book).ToListAsync();

            if (genreId != 0 && sTerm != null)
            {

                books = await (from book in _db.books
                               join genre in _db.genres
                               on book.genre_Id equals genre.genre_Id
                               where genre.genre_Id == genreId && book.book_Title == sTerm
                               select book).ToListAsync();
                /*books = books.Where(a => a.book_Id == genreId).ToList();*/
            }
            else if (genreId != 0 && sTerm == null)
            {
                books = await (from book in _db.books
                               join genre in _db.genres
                               on book.genre_Id equals genre.genre_Id
                               where genre.genre_Id == genreId
                               select book).ToListAsync();
            }
            return books;

        }


        public async Task<IEnumerable<Book>> GetBooks(string sTerm = "", int genreId = 0)
        {

            IEnumerable<Book> books = await (from book in _db.books
                                             join genre in _db.genres
                                             on book.genre_Id equals genre.genre_Id
                                             where string.IsNullOrWhiteSpace(sTerm) || (book != null && book.book_Title.ToLower().StartsWith(sTerm))
                                             select book).ToListAsync();

            if (genreId != 0 && sTerm != null)
            {

                books = await (from book in _db.books
                               join genre in _db.genres
                               on book.genre_Id equals genre.genre_Id
                               where genre.genre_Id == genreId && book.book_Title == sTerm
                               select book).ToListAsync();
                /*books = books.Where(a => a.book_Id == genreId).ToList();*/
            }
            else if (genreId != 0 && sTerm == null)
            {
                books = await (from book in _db.books
                               join genre in _db.genres
                               on book.genre_Id equals genre.genre_Id
                               where genre.genre_Id == genreId
                               select book).ToListAsync();
            }
            return books;

        }

    }
}