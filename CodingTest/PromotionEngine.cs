using System;
using System.Linq;

namespace CodingTest
{
    public class PromotionEngine : IPromotion
    {
        public IPromotionResult ApplyPromotion(IPromotionFactory promotionFactory, IPromotionRule promotion, IItemList items)
        {
            throw new NotImplementedException();
        }

        public IPromotionResult ApplyPromotion(IPromotionRule promotion, IItemList items)
        {
            PromotionResult objResult = new PromotionResult();
            if (promotion.IsOnSingleItem)
            {
                var strItemName = promotion.GetItemName();
                var itemQty = promotion.GetItemQty();

                var itemList = items.GetItemList(); 
                foreach(var item in itemList)
                {
                    if(item.ItemObj.ItemName == strItemName) 
                    {
                        if(item.ItemQuantity < itemQty)
                        {
                            //Promotion cannot be applied.
                            objResult.PromotionApplied = false;
                        }
                        else
                        {
                            if (item.ItemQuantity == itemQty)
                            {
                                item.AmountPayable = promotion.GetRuleAmount();
                            }
                            else
                            {
                                int multiplier = item.ItemQuantity / itemQty;
                                int remain = item.ItemQuantity % itemQty;
                                item.AmountPayable = (promotion.GetRuleAmount() * multiplier) + (item.ItemObj.ItemPrice * remain);
                            }
                            objResult.PromotionApplied = true;
                        }
                        break;
                    }
                }
            }
            return objResult; 
        }
    }
}
