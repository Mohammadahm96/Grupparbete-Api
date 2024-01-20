using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ShoppingArticleModel
    {
        [Key]
        public Guid ArticleId { get; set; }
        public string? ArticleName { get; set; }
        public int? ArticleQuantity { get; set; }
        public bool? IsAvailable { get; set; }
    }
}