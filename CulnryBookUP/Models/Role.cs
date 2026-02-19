using System.ComponentModel.DataAnnotations;
namespace CulnryBookUP.Models
{
    public class Role
    {
        [Key] public int IdRole { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Role() { }

        public Role
        (
            string roleName
        )
        {
            RoleName = roleName;
        }
    }
}
