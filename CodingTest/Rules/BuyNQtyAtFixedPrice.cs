namespace CodingTest.Rules
{
    public class BuyNQtyAtFixedPrice : PromotionRule
    {
        public int ItemMinQtyToAvailThisOffer { get; set; }
        public string ItemName;
        public BuyNQtyAtFixedPrice(string pName, double pAmount, int minQty, string itemName) : base(pName,pAmount)
        {
                ItemMinQtyToAvailThisOffer = minQty;
                IsOnSingleItem = true;
                ItemName = itemName;
        }
        //public BuyNQtyAtFixedPrice(string promotionName, double promotionAmount, int minQty )
        //   {
        //       //base(promotionName, promotionAmount);
        //       ItemMinQtyToAvailThisOffer = minQty;
        //       IsOnSingleItem = true;
        //   }

        public override double GetRuleAmount()
        {
            return PromotionAmount;
        }
        public override string GetItemName()
        {
            return ItemName;
        }
        public override int GetItemQty()
        {
           return ItemMinQtyToAvailThisOffer;
        }

    }
}
