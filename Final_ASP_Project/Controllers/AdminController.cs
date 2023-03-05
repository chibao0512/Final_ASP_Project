using Final_ASP_Project.DSRole;
using Final_ASP_Project.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_ASP_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _db;
       
        public AdminController(ApplicationDbContext db,
            UserManager<ApplicationUser> userManager,
            IFileService fileService)
        {
            _db = db;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Admin/RequestGenre")]
        public IActionResult RequestGenre()
        {
            var Genre = _db.genres.Where(c => c.genre_Status == "processing").ToList();
            return View(Genre);
        }

        [Route("Admin/RequestGenre/Approval")]
        public IActionResult Approval(int id)
        {
            Genre genre = _db.genres.Find(id);
            if (genre == null)
            {
                return RedirectToAction("RequestGenre");
            }
            else
            {
                genre.genre_Status = "processed";
                _db.genres.Update(genre);
                _db.SaveChanges();
                return RedirectToAction("RequestGenre");
            }

        }


        [Route("Admin/RequestGenre/Reject")]
        public IActionResult Reject(int id)
        {
            Genre genre = _db.genres.Find(id);
            if (genre == null)
            {
                return RedirectToAction("RequestGenre");
            }
            else
            {
                _db.genres.Remove(genre);
                _db.SaveChanges();
                return RedirectToAction("RequestGenre");
            }
        }
        [Route("Admin/ShowUser")]
        public async Task<IActionResult> ShowUser()
        {
            var user = await (from users in _db.Users
                              join UserRole in _db.UserRoles
                              on users.Id equals UserRole.UserId
                              join role in _db.Roles
                              on UserRole.RoleId equals role.Id
                              where role.Name == "Customer"
                              select users).ToListAsync();
            return View(user);
        }

        [Route("Admin/ShowOwner")]
        public async Task<IActionResult> ShowOwner()
        {
            var owner = await (from users in _db.Users
                               join UserRole in _db.UserRoles
                               on users.Id equals UserRole.UserId
                               join role in _db.Roles
                               on UserRole.RoleId equals role.Id
                               where role.Name == "Owner"
                               select users).ToListAsync();
            return View(owner);
        }

        [Route("Admin/ShowOwner/EditOwner/{id:}")]
        public IActionResult EditOwner(string id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("ShowOwner");
            }
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        [Route("Admin/ShowOwner/EditOwner/{id:}")]
        public async Task<IActionResult> EditOwner(string ownerid, ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var owner = await _userManager.FindByIdAsync(ownerid);
                var result = await _userManager.ChangePasswordAsync(owner, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    TempData["Password"] = "Invalid password!";
                    return View(model);
                }

                return RedirectToAction("ShowOwner");
            }
            else
            {
                return View(model);
            }

        }

        [Route("Admin/ShowOwner/EditUser/{id:}")]
        public IActionResult EditUser(string id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return RedirectToAction("ShowUser");
            }
            ViewData["id"] = id;
            return View();
        }


        [HttpPost]
        [Route("Admin/ShowOwner/EditUser/{id:}")]
        public async Task<IActionResult> EditUser(string userid, ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userid);
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {
                    TempData["Password"] = "Invalid password!";
                    return View(model);
                }
                return RedirectToAction("ShowUser");

            }
            else
            {
                return View(model);
            }

        }
        [Route("Admin/RegisterAccOwner")]
        public async Task<IActionResult> RegisterAccOwner()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/RegisterAccOwner")]
        public async Task<IActionResult> RegisterAccOwner(Account acc)
        {
            if (ModelState.IsValid)
            {
                var owner = new ApplicationUser
                {
                    UserName = acc.Email,
                    FullName = acc.Name,
                    Email = acc.Email,
                    PhoneNumber = acc.Phone,


                };
                var result = await _userManager.CreateAsync(owner, acc.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(owner, Role.Owner.ToString());
                    return RedirectToAction("ShowOwner");
                }
                else
                {
                    TempData["Fail"] = "RegisterOwner Fail!";
                    return RedirectToAction("RegisterAccOwner");
                }
            }
            return RedirectToAction("RegisterAccOwner");
        }
    }
}
