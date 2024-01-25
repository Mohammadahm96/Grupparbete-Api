namespace Application.Dto
{
    public class UpdateFamilyShoppingListDto
    {
        public Guid FamilyId { get; set; }
        public Guid ArticleId { get; set; }
        public required string ArticleName { get; set; }

    }
}
