using System;
using System.Collections.Generic;
using CodingTest.Models;

namespace CodingTest
{
    public interface IPromotionRule
    {
        public string PromotionName { get; set; }
        public double PromotionAmount { get; set; }
        public Boolean IsOnSingleItem { get; set; }
        public double GetRuleAmount();

        public string GetItemName();

        public List<KeyValuePair<Item, int>> GetItemCombinationList();

        public int GetItemQty();

       }
}