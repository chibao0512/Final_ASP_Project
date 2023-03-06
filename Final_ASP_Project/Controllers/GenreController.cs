using Final_ASP_Project.Data;
using Final_ASP_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_ASP_Project.Controllers
{
    public class GenreController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenreController(ApplicationDbContext db)
        {
            _db = db;
        }

        // index
        public IActionResult Index()
        {
            IEnumerable<Genre> genre = _db.genres.Where(c => c.genre_Status == "prosessed").ToList();
            return View(genre);
        }

        // create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genre.genre_Status = "Processing";
                _db.genres.Add(genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // edit
        public IActionResult Edit(int id)
        {
            Genre genre = _db.genres.Find(id);
            if (genre == null)
            {
                return RedirectToAction("Index");
            }
            return View(genre);
        }
        [HttpPost]
        public IActionResult Edit(Genre genre, int id)
        {
            if (ModelState.IsValid)
            {
                genre.genre_Id = id;
                genre.genre_Status = "prosessed";
                _db.genres.Update(genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // delete
        public ActionResult Delete(int id)
        {
            Genre Genre = _db.genres.Find(id);
            if (Genre == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                _db.genres.Remove(Genre);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
