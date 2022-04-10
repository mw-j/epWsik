namespace epAPI.DTOs
{
    [TsInterface]
    public class IngredientDTO
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; } = "";
        public int? ShelfLife { get; set; }
        public int Amount { get; set; }
    }
}
