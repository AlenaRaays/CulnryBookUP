using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulnryBookUP.Models
{
    public class RecipeIngredients
    {
        [Key] public int RecipeIngredientID { get; set; }
        [Required, ForeignKey("idRecipe")] public int idRecipe { get; set; }
        public virtual Recipe Recipe { get; set; }
        [Required, ForeignKey("IntgredientID")] public int IntgredientID { get; set; }
        public virtual Ingredients Ingredients { get; set; }
        [Required] public int Quantity { get; set; }

        public RecipeIngredients() { }
        public RecipeIngredients(int idrecipe, int ingredientID, int quantity)
        {
            idRecipe = idrecipe;
            IntgredientID = ingredientID;
            Quantity = quantity;
        }
    }
}
