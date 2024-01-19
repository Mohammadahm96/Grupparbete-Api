using System.Text.Json.Serialization;

namespace Application.Dto
{
    public class FamilyShoppingListDto
    {
        [JsonIgnore]
        public Guid FamilyId { get; set; }
        public required string ArticleName { get; set; }
        public int ArticleQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}