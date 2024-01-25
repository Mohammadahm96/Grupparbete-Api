namespace Domain.Models.ListModels
{
    public class SommarHusArticleList : ShoppingArticleModel
    {
        public Guid SommarHusId { get; set; }
        public required string HouseName { get; set; }
    }
}
