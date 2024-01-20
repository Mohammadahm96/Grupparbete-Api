using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.ListModels
{
    public class FamilyArticleList : ShoppingArticleModel
    {
        public Guid FamilyId { get; set; }
        public string? FamilyName { get; set; }
    }
}