using CulnryBookUP.Data;
using CulnryBookUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CulnryBookUP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var _users = _context.Users.Include(u => u.Role).ToList();
            return View(_users);
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var _users = _context.Users.ToList();

            User user = null;
            foreach (var u in _users)
            {
                if (u.Login == model.login)
                {
                    user = u;
                    break;
                }
            }

            if (user != null && user.Password == model.password)
            {
                HttpContext.Session.SetString("UserId", user.IdUser.ToString());
                HttpContext.Session.SetString("UserName", user.UserName.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Неверный догин или пароль";
                return View(model);
            }
        }
        
    }
}
