using System;
using System.Linq;
using CodingTest.Models;
using System.Collections.Generic;

namespace CodingTest
{
    public class PromotionEngine : IPromotion
    {
        public IPromotionResult ApplyPromotion(IPromotionFactory promotionFactory, IPromotionRule promotion, IItemList items)
        {
            throw new NotImplementedException();
        }

        public IPromotionResult ApplyPromotion(IPromotionRule promotion, IItemList items, bool onSingleItem)
        {
           PromotionResult objResult = new PromotionResult();
           var strItemName = promotion.GetItemName();
           var itemQty = promotion.GetItemQty();
           var itemList = items.GetItemList();
                
           try
           {
                var item = itemList.Where(ci => ci.ItemObj.ItemName == strItemName && ci.ItemQuantity >= itemQty).Select(ci => ci).Single();
                int multiplier = item.ItemQuantity / itemQty;
                int remain = item.ItemQuantity % itemQty;
                item.AmountPayable = (promotion.GetRuleAmount() * multiplier) + (item.ItemObj.ItemPrice * remain);
                objResult.PromotionApplied = true;
            }
           catch(Exception)
           {
                    objResult.PromotionApplied = false;
           }
            return objResult; 
        }

        public void ApplyPromotion(IPromotionRule promotion, IItemList items)
        {
                ApplyPromotionForItemsCombination(promotion, items);
        }
        private void  ApplyPromotionForItemsCombination(IPromotionRule promotion, IItemList items)
        {
            var discountCombinationItems = promotion.GetItemCombinationList();
            var shoppingCartClone = items.GetItemList();
            
            var itemsMarkedForDiscount = new List<KartItem>();

            var eligibleForDiscount = false;
            foreach (var itemsCountsCombination in discountCombinationItems)
            {
                var shoppedItem = items.GetItemList()  
                    .Where(ci => ci.ItemObj == itemsCountsCombination.Key)
                    .Select(ci => ci)
                    .Single();

                if (shoppedItem.Equals(new KeyValuePair<Item, int>()))
                {
                    eligibleForDiscount = false;
                    break;
                }

                if (shoppedItem.ItemQuantity  >= itemsCountsCombination.Value)
                {
                    eligibleForDiscount = true;
                    itemsMarkedForDiscount.Add(new KartItem (shoppedItem.ItemObj, shoppedItem.ItemQuantity));
                    var prod = shoppedItem.ItemObj;
                    
                    shoppingCartClone.Remove(shoppedItem);
                    var remainingCount = shoppedItem.ItemQuantity % itemsCountsCombination.Value;
                   shoppingCartClone.Add(new KartItem(prod, remainingCount));
                }
            }

            if (eligibleForDiscount)
            {
                int[] arr = new int[itemsMarkedForDiscount.Count];
                int i = 0;
                // We need to iterate through the collection to get the multipler for promotional KartItem
                foreach(var it in itemsMarkedForDiscount )
                {
                    arr[i] = it.ItemQuantity;
                    i++;
                }
                int multiplier = arr.Min();

                //Once we get the correct multipler, we need to correct Quantity in original Kart, so that correct amount can be calculated.
                foreach (var it in itemsMarkedForDiscount)
                {
                    var shoppedItem = items.GetItemList()
                    .Where(ci => ci.ItemObj == it.ItemObj)
                    .Select(ci => ci)
                    .Single();

                    shoppedItem.ItemQuantity += it.ItemQuantity - multiplier;
                    shoppedItem.AmountPayable = shoppedItem.ItemQuantity * shoppedItem.ItemObj.ItemPrice;
                }

                //Here we are adding new KartItem for promotion items.
                double amount = promotion.PromotionAmount * multiplier;
                Item itm = new Item();
                itm.ItemName = promotion.PromotionName;
                itm.ItemPrice = promotion.PromotionAmount;
                KartItem ktm = new KartItem(itm, multiplier);
                items.AddKartItem(ktm);
            }
           else //reverse and restore
            {
                itemsMarkedForDiscount.ForEach(it =>
                {
                    shoppingCartClone.Remove(shoppingCartClone.Find(p => p.ItemObj == it.ItemObj));
                    shoppingCartClone.Add(it);
                });
            }
           
        }
    }
}
