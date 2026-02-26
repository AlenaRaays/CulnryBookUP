using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace CulnryBookUP.Models
{
    public class User
    {
        [Key] public int IdUser { get; set; }
        [Required (ErrorMessage = "Имя обязательно"), StringLength(20, MinimumLength = 3)] public string UserName { get; set; }
        [Required(ErrorMessage = "Логин обязателен"), StringLength(20, MinimumLength = 3)] public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязателен"), StringLength(20, MinimumLength = 8)] public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный email")] public string Email { get; set; }
        [ForeignKey("IdRole")] public int IdRole { get; set; } = 1;
        public virtual Role Role { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
        public User() { }

        public User
        (
            string name, string login, string password,
            string email
        )
        {
            UserName = name;
            Login = login;
            Password = password;
            Email = email;
        }

    }
}
