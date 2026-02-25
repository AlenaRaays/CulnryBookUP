namespace CulnryBookUP.Models
{
    public class LoginModel
    {
        public string login {  get; set; }
        public string password { get; set; }
        public Role? role { get; set; }
        public int? IdRole { get; set; }
    }
}
