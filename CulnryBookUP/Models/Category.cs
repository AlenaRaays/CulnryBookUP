using System.ComponentModel.DataAnnotations;

namespace CulnryBookUP.Models
{
    public class Category
    {
        [Key] public int IdCategory { get; set; }
        [Required] public string NameCategory { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public Category() { }

        public Category(int idCategory, string nameCategory)
        {
            IdCategory = idCategory;
            NameCategory = nameCategory;
        }
    }
}
