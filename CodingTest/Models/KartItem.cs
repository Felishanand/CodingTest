using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.Models
{
    public class KartItem
    {
        public Item ItemObj { get; set; }
        public int ItemQuantity { get; set; }
        public double AmountPayable { get; set; }

        public KartItem(Item itmObj, int itmQty = 0, double amtPayable = 0)
        {
            ItemObj = itmObj;
            ItemQuantity = itmQty;

            //We need to create new Record for KartItem, once promotion is applied.
            //In that case amount Payable will send directly after appliying promotion.
            if(amtPayable == 0)
            {
                AmountPayable = ItemQuantity * ItemObj.ItemPrice;
            }                
            else
            {
                AmountPayable = amtPayable;
            }
        }
    }
}
