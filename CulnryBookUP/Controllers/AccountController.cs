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
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel model, string login, string password)
        {
            var _users = _context.Users.ToList();

            User user = _users.FirstOrDefault(x => x.Login == model.login && x.Password == model.password);

            if (user != null && user.Login == model.login && user.Password == model.password)
            {
                return Redirect("~/Recipe/Index");
            }
            else
            {
                ViewBag.Error = "Неверный догин или пароль";
                return View(model);
            }
        } 
    }
}
