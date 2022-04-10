namespace epDataAccess.Models
{
    public class RecipeModel
    {
        public Guid RecipeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int WorkingTime { get; set; }
        public int PreparationTime { get; set; }
        public List<IngredientAmountModel> Ingredients { get; set; } = new List<IngredientAmountModel>();
    }
}
