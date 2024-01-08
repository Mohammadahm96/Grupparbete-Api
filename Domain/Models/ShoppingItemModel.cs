namespace Domain.Models
{
    public class ShoppingItemModel
    {
        public Guid ShoppingItemId { get; set; }
        public required string ShoppingItemName { get; set; }
        public int Quantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}