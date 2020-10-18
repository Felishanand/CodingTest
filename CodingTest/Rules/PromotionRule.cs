using CodingTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.Rules
{
    public abstract class PromotionRule : IPromotionRule
    {
        private string promotionName;
        private double promotionAmount;
        private bool isOnSingleItem;

        public string PromotionName { get => promotionName; set => promotionName = value; }
        public double PromotionAmount { get => promotionAmount; set => promotionAmount = value; }
        public bool IsOnSingleItem { get => isOnSingleItem; set => isOnSingleItem = value; }

        public PromotionRule(string pName, double pAmount)
        {
            promotionName = pName;
            promotionAmount = pAmount;
            IsOnSingleItem = false;
        }
        public virtual double GetRuleAmount()
        {
            throw new NotImplementedException();
        }
        public virtual List<KeyValuePair<Item,int>> GetItemCombinationList()
        {
            throw new NotImplementedException();
        }
        public virtual string GetItemName()
        {
            throw new NotImplementedException();
        }

        public virtual int GetItemQty()
        {
            throw new NotImplementedException();
        }

 
    }
}
