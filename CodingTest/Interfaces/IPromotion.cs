using System.Security.Cryptography.X509Certificates;

namespace CodingTest
{
    public interface IPromotion
    {
        IPromotionResult ApplyPromotion(IPromotionFactory promotionFactory, IPromotionRule promotion, IItemList items);

        IPromotionResult ApplyPromotion( IPromotionRule promotion, IItemList items, bool singleItemRule);

        void ApplyPromotion(IPromotionRule promotion, IItemList items);
    }
}
