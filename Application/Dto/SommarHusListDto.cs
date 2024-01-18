namespace Application.Dto
{
    public class SommarHusListDto
    {
        public required string HouseName { get; set; }
        public required string ArticleName { get; set; }
        public int ArticleQuantity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
