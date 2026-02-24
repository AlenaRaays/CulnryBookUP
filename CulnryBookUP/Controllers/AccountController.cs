using CulnryBookUP.Data;
using CulnryBookUP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace CulnryBookUP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;
        public AccountController(ApplicationDbContext context,ILogger<AccountController> logger)
        {
            _context = context;
            _logger = logger;
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
                return Json(new {success = true});
            }
            else
            {
                return Json(new { success = false });
            }
        } 
    }
}
