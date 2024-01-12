namespace Domain.Models
{
    public class ShoppingArticleModel
    {
        public Guid ArticleId { get; set; }
        public required string ArticleName { get; set; }
        public int ArticleQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}