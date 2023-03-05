using Final_ASP_Project.Data;
using Final_ASP_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_ASP_Project.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }


        // index
        public IActionResult Index()
        {
            IEnumerable<Book> book = _db.books.Include(b => b.genre).ToList();
            return View(book);
        }

        // create
        public IActionResult Create()
        {
            ViewData["genre_Id"] = new SelectList(_db.genres, "genre_Id", "genre_Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                string fileName = UploadFile(book);
                book.book_urlImage = fileName;
                _db.books.Add(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }


        public string UploadFile(Book book)
        {
            string FileName = null;

            if (book.book_Img != null)
            {
                string uploadsFoder = Path.Combine("wwwroot", "uploads");
                // name file
                FileName = Guid.NewGuid().ToString() + book.book_Id + book.book_Img.FileName;
                string filePath = Path.Combine(uploadsFoder, FileName);
                // copy ve code
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    book.book_Img.CopyTo(fileStream);
                }
            }
            return  FileName;
        }
        // edit

        public IActionResult Edit(int id)
        {
            ViewData["genre_Id"] = new SelectList(_db.genres, "genre_Id", "genre_Name");
            Book book = _db.books.Find(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }
      
    
        public IActionResult Edit(Book book, int id, string img)
        {
            book.book_Id=id;
            if (ModelState.IsValid)
            {
                if (book.book_Img == null)
                {
                    book.book_urlImage = img;
                    _db.books.Update(book);
                    _db.SaveChanges();
                }
                else
                {
                    book.book_Id = id;
                    string uniqueFileName = UploadFile(book);
                    book.book_urlImage = uniqueFileName;

                    _db.books.Update(book);
                    _db.SaveChanges();

                    img = Path.Combine("wwwroot", "uploads", img);

                    FileInfo infor = new FileInfo(img);
                    if (infor != null)
                    {
                        System.IO.File.Delete(img);
                        infor.Delete();
                    }
                }

                return RedirectToAction("Index");
            }
            return View(book);
        }

        // delete
        [Route("/Book/Delete/{id:}")]
        public IActionResult Delete(int id)
        {
            Book book = _db.books.Find(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _db.books.Remove(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id, string img)
        {
            Book book = _db.books.Find(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                img = Path.Combine("wwwroot", "uploads", img);
                FileInfo infor = new FileInfo(img);
                if (infor != null)
                {
                    System.IO.File.Delete(img);
                    infor.Delete();
                }
                _db.books.Remove(book);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public async Task<IEnumerable<Book>> GetBooks()
        {
            IEnumerable<Book> books = await (from book in _db.books
                                             join genre in _db.genres
                                             on book.genre_Id equals genre.genre_Id
                                             select new Book
                                             {
                                                 book_Id = book.book_Id,
                                                 book_urlImage = book.book_urlImage,
                                                 genre = book.genre,
                                                 book_Title = book.book_Title,
                                                 genre_Id = book.genre_Id,
                                                 Book_Price = book.Book_Price,
                                                 book_Quantity = book.book_Quantity,
                                                 publication_date = book.publication_date,
                                                 book_Description = book.book_Description
                                             }
                         ).ToListAsync();
            return books;

        }
    }
}
