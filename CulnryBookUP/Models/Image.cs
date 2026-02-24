using System.ComponentModel.DataAnnotations;

namespace CulnryBookUP.Models
{
    public class Image
    {
        [Key] public int ImageID { get; set; }
        public int IdRecipe { get; set; }
        public string? ImagePath { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public Image() { }
        public Image(int IDRecipe, string? imagePath)
        {
            IdRecipe = IDRecipe;
            ImagePath = imagePath;
        }
    }
}
