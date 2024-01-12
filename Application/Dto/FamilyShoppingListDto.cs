namespace Application.Dto
{
    public class FamilyShoppingListDto
    {
        public required string ArticleName { get; set; }
        public int ArticleQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}