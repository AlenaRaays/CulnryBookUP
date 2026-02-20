using CulnryBookUP.Data;
using CulnryBookUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using CulnryBookUP.Models;

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


            return Content($"Здравствуйте, {user.UserName}! \nВы зарегестрировались!");

        }
    }
}
