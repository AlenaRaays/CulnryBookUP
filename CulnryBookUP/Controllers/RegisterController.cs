using CulnryBookUP.Data;
using CulnryBookUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CulnryBookUP.Models;
using System.Runtime.CompilerServices;

namespace CulnryBookUP.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;
        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string userName, string login, string password, string email, string roleID)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            else
            {
                var user = new User()
                {
                    UserName = userName,
                    Login = login,
                    Password = password,
                    Email = email,
                    RoleID = 1
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return Redirect("/Account/Index");
            }
        }
    }
}
