using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace CulnryBookUP.Models
{
    public class User
    {
        [Key] public int IdUser { get; set; }
        [Required (ErrorMessage = "Имя обязательно"), StringLength(50, MinimumLength = 3)] public string UserName { get; set; }
        [Required(ErrorMessage = "Логин обязателен"), StringLength(50, MinimumLength = 3)] public string Login { get; set; }
        [Required(ErrorMessage = "Пароль обязателен"), StringLength(50, MinimumLength = 8)] public string Password { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный email")] public string Email { get; set; }
        [ForeignKey("RoleID")] public int RoleID { get; set; }
        public virtual Role Role { get; set; }

        public User() { }

        public User
        (
            string name, string login, string password,
            string email, int roleID
        )
        {
            UserName = name;
            Login = login;
            Password = password;
            Email = email;
            RoleID = roleID;
        }

    }
}
