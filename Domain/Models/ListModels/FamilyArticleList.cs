using System.ComponentModel.DataAnnotations;

namespace Domain.Models.ListModels
{
    public class FamilyArticleList : ShoppingArticleModel
    {
        public Guid FamilyId { get; set; }
        public string? FamilyName { get; set; }
    }
}