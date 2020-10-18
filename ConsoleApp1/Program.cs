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

            IPromotionRule objRule = new BuyNQtyAtFixedPrice("Promotion A", 130, 3,"A");

            IPromotion objPromotion = new PromotionEngine();

            objPromotion.ApplyPromotion(objRule, objKart);
            objRule = new BuyNQtyAtFixedPrice("Promotion B", 45, 2, "B");

            objPromotion.ApplyPromotion(objRule, objKart);

            Console.WriteLine("Total Amount Payable :" + objKart.CalculateAmountPayable());
            List<KeyValuePair<Item, int>> kvpList = new List<KeyValuePair<Item, int>>();
            kvpList.Add(new KeyValuePair<Item, int>(objItemC, 1));
            kvpList.Add(new KeyValuePair<Item, int>(objItemD, 1));

            List<KartItem> objPurchasedItemList1 = new List<KartItem>();
            
            KartItem objKartItem5 = new KartItem(objItemC, 2);
            KartItem objKartItem6 = new KartItem(objItemD, 1);

            objPurchasedItemList1.Add(objKartItem5);
            objPurchasedItemList1.Add(objKartItem6);

            Kart objKart1 = new Kart(objPurchasedItemList1);

            objRule = new BuyNItemsAtFixedPrice("Combination C & D", 30, kvpList);
            objPromotion.ApplyPromotion(objRule, objKart1);
            objPromotion.ApplyPromotion(objRule, objKart);
            Console.WriteLine("Total Amount Payable for Kart :" + objKart.CalculateAmountPayable());
            Console.WriteLine("Total Amount Payable :" + objKart1.CalculateAmountPayable());
            Console.WriteLine("Hello World!");

            Console.ReadLine();
        }
    }
}
