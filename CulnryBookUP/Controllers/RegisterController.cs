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
        public IActionResult Index(string userName, string login, string password, string email)
        {
            if (!ModelState.IsValid)
            {
                return Content(ModelState.Values.ToString());
            }

            else
            {
                var user = new User(userName,login,password,email)
                {
                    UserName = userName,
                    Login = login,
                    Password = password,
                    Email = email,
                };

                _context.Users.Add(user);
                _context.SaveChanges();
                return Redirect("~/Account/Index");
            }
        }
    }
}
