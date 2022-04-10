namespace epAPI.DTOs
{
    [TsInterface]
    public class RecipeDTO
    {
        public Guid RecipeId { get; set; }
        public string Title { get; set; } = "";
        public int? WorkingTime { get; set; }
        public int? PreparationTime { get; set; }
        List<IngredientDTO> Ingredients { get; set; } = new List<IngredientDTO>();
    }
}
