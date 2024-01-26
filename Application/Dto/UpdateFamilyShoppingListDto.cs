namespace Application.Dto
{
    public class UpdateFamilyShoppingListDto
    {
        public Guid FamilyId { get; set; }
        public Guid ArticleId { get; set; }
        public string ArticleName { get; set; }

    }
}
