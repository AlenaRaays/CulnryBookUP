using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulnryBookUP.Models
{
    public class CookingStep
    {
        [Key] public int StepID {  get; set; }
        [Required, ForeignKey("idRecipe")] public int idRecipe { get; set; }
        public virtual Recipe Recipe { get; set; }
        [Required] public int StepNumber { get; set; }
        [Required] public string StepDescription { get; set; }

        public CookingStep() { }
        public CookingStep(int idrecipe, int stepNumber, string stepDescription)
        {
            idRecipe = idrecipe;
            StepNumber = stepNumber;
            StepDescription = stepDescription;
        }

    }
}
