namespace Domain.Models.ListModels
{
    public class SommarHusArticleList : ShoppingArticleModel
    {
        public Guid Id { get; set; }
        public required string HouseName { get; set; }
    }
}
