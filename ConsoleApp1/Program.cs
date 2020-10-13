using System;
using System.Collections.Generic;
using CodingTest;
using CodingTest.Models;
using CodingTest.Rules;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Item objItemA = new Item() { ItemId = 1, ItemName = "A", Description = "Test Item A", ItemPrice = 50 };
            Item objItemB = new Item() { ItemId = 2, ItemName = "B", Description = "Test Item B", ItemPrice = 30 };
            Item objItemC = new Item() { ItemId = 3, ItemName = "C", Description = "Test Item C", ItemPrice = 20};
            Item objItemD = new Item() { ItemId = 4, ItemName = "D", Description = "Test Item D", ItemPrice = 15 };

            KartItem objKartItem1 = new KartItem(objItemA,  8);
            KartItem objKartItem2 = new KartItem(objItemB, 5);
            KartItem objKartItem3 = new KartItem(objItemC, 1);
            KartItem objKartItem4 = new KartItem(objItemD, 1);

            List<KartItem> objPurchasedItemList = new List<KartItem>();
            
            objPurchasedItemList.Add(objKartItem1);
            objPurchasedItemList.Add(objKartItem2);
            objPurchasedItemList.Add(objKartItem3);
            objPurchasedItemList.Add(objKartItem4);

            Kart objKart = new Kart(objPurchasedItemList) ;

            IPromotionRule objRule = new BuyNQtyAtFixedPrice("A", 130, 3,"A");

            IPromotion objPromotion = new PromotionEngine();

            objPromotion.ApplyPromotion(objRule, objKart);
            objRule = new BuyNQtyAtFixedPrice("B", 45, 2, "B");

            objPromotion.ApplyPromotion(objRule, objKart);

            Console.WriteLine("Total Amount Payable :" + objKart.CalculateAmountPayable());
            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
