using CodingTest.Models;
using System.Collections.Generic;

namespace CodingTest.Rules
{
    public class BuyNItemsAtFixedPrice : PromotionRule
    {
        private List<KeyValuePair<Item, int>> _ItemCombination;   // It contains the combination for Item and Qty for discount.

        public BuyNItemsAtFixedPrice(string pName, double pAmount, List<KeyValuePair<Item, int>> itemCombination) : base(pName, pAmount)
        {
            _ItemCombination = itemCombination;
        }
        public override List<KeyValuePair<Item, int>> GetItemCombinationList()
        {
            return _ItemCombination;
        }
        public override double GetRuleAmount()
        {
            return PromotionAmount;
        }
    }
   
}
