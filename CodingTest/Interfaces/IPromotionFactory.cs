namespace CodingTest
{
    public interface IPromotionFactory
    {
        public IPromotion GetPromotionObject(string promotionName);
    }
}