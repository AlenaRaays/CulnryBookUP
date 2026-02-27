namespace CulnryBookUP.Models
{
    public class AddRecipeViewModel
    {
        public string RecipeName { get; set; }
        public string RecipeDescr { get; set; }
        public int CategoryID { get; set; }
        public int CookingTime { get; set; }
        public List<IngredientFormItem> Ingredients { get; set; }
        public List<RecipeIngredientFormItem> RecipeIngredients { get; set; }
        public List<CookingStepFormItem> CookingStep { get; set; }
        public IFormFile? ImageFile { get; set; }

        public AddRecipeViewModel()
        {
            Ingredients = new List<IngredientFormItem>();
            RecipeIngredients = new List<RecipeIngredientFormItem>();
            CookingStep = new List<CookingStepFormItem>();
        }
    }

    public class IngredientFormItem
    {
        public string IngredientName { get; set; }
    }

    public class RecipeIngredientFormItem
    {
        public int Quantity { get; set; }
    }

    public class CookingStepFormItem
    {
        public string StepDescription { get; set; }
    }
}
