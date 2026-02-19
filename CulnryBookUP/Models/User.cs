using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace CulnryBookUP.Models
{
    public class User
    {
        [Key] public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [ForeignKey("RoleID")]
        public int RoleID { get; set; }
        public virtual Role? Role { get; set; }

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
