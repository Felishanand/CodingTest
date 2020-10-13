using System;

namespace CodingTest
{
    public interface IPromotionRule
    {
        public string PromotionName { get; set; }
        public double PromotionAmount { get; set; }
        public Boolean IsOnSingleItem { get; set; }
        public double GetRuleAmount();

        public string GetItemName();

        public string[] GetItemNames();

        public int GetItemQty();

        public int[] GetItemQtys();
    }
}