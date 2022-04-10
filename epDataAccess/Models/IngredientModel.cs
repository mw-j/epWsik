namespace epDataAccess.Models
{
    public class IngredientModel
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ShelfLife { get; set; }

    }
}
