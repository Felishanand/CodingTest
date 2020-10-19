using System;
using System.Collections.Generic;
using System.Text;
using CodingTest.Models;
using CodingTest;
using CodingTest.Rules;
using NUnit.Framework;

namespace UnitTestProject
{
    class PromotionRuleTest
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void ComputeBillScenarioATest()
        {
            Item objItemA = new Item() { ItemId = 1, ItemName = "A", Description = "Test Item A", ItemPrice = 50 };
            Item objItemB = new Item() { ItemId = 2, ItemName = "B", Description = "Test Item B", ItemPrice = 30 };
            Item objItemC = new Item() { ItemId = 3, ItemName = "C", Description = "Test Item C", ItemPrice = 20 };
            Item objItemD = new Item() { ItemId = 4, ItemName = "D", Description = "Test Item D", ItemPrice = 15 };

            KartItem objKartItem1 = new KartItem(objItemA, 1);
            KartItem objKartItem2 = new KartItem(objItemB, 1);
            KartItem objKartItem3 = new KartItem(objItemC, 1);
            
            List<KartItem> objPurchasedItemList = new List<KartItem>();

            objPurchasedItemList.Add(objKartItem1);
            objPurchasedItemList.Add(objKartItem2);
            objPurchasedItemList.Add(objKartItem3);

            Kart objKart = new Kart(objPurchasedItemList);

            //Now setup the Promotions Rules
            IPromotionRule objRuleA = new BuyNQtyAtFixedPrice("Promotion A", 130, 3, "A");
            IPromotionRule  objRuleB =  new BuyNQtyAtFixedPrice("Promotion B", 45, 2, "B");
            
            //Creating instance of RuleEngine
            IPromotion objPromotion = new PromotionEngine();

            objPromotion.ApplyPromotion(objRuleA, objKart);
            objPromotion.ApplyPromotion(objRuleB, objKart);
            
            Assert.AreEqual(100, objKart.CalculateAmountPayable());
        }

        [Test]
        public void ComputeBillScenarioBTest()
        {
            Item objItemA = new Item() { ItemId = 1, ItemName = "A", Description = "Test Item A", ItemPrice = 50 };
            Item objItemB = new Item() { ItemId = 2, ItemName = "B", Description = "Test Item B", ItemPrice = 30 };
            Item objItemC = new Item() { ItemId = 3, ItemName = "C", Description = "Test Item C", ItemPrice = 20 };

            KartItem objKartItem1 = new KartItem(objItemA, 5);
            KartItem objKartItem2 = new KartItem(objItemB, 5);
            KartItem objKartItem3 = new KartItem(objItemC, 1);

            List<KartItem> objPurchasedItemList = new List<KartItem>();

            objPurchasedItemList.Add(objKartItem1);
            objPurchasedItemList.Add(objKartItem2);
            objPurchasedItemList.Add(objKartItem3);

            Kart objKart = new Kart(objPurchasedItemList);

            IPromotionRule objRuleA = new BuyNQtyAtFixedPrice("Promotion A", 130, 3, "A");
            IPromotionRule objRuleB = new BuyNQtyAtFixedPrice("Promotion B", 45, 2, "B");

            IPromotion objPromotion = new PromotionEngine();

            objPromotion.ApplyPromotion(objRuleA, objKart);
            objPromotion.ApplyPromotion(objRuleB, objKart);

            Assert.AreEqual(370, objKart.CalculateAmountPayable());
        }

        [Test]
        public void ComputeBillScenarioCTest()
        {
            Item objItemA = new Item() { ItemId = 1, ItemName = "A", Description = "Test Item A", ItemPrice = 50 };
            Item objItemB = new Item() { ItemId = 2, ItemName = "B", Description = "Test Item B", ItemPrice = 30 };
            Item objItemC = new Item() { ItemId = 3, ItemName = "C", Description = "Test Item C", ItemPrice = 20 };
            Item objItemD = new Item() { ItemId = 4, ItemName = "D", Description = "Test Item D", ItemPrice = 15 };

            KartItem objKartItem1 = new KartItem(objItemA, 3);
            KartItem objKartItem2 = new KartItem(objItemB, 5);
            KartItem objKartItem3 = new KartItem(objItemC, 1);
            KartItem objKartItem4 = new KartItem(objItemD, 1);

            List<KartItem> objPurchasedItemList = new List<KartItem>();

            objPurchasedItemList.Add(objKartItem1);
            objPurchasedItemList.Add(objKartItem2);
            objPurchasedItemList.Add(objKartItem3);
            objPurchasedItemList.Add(objKartItem4);

            Kart objKart = new Kart(objPurchasedItemList);

            //Now setup the Promotions Rules
            List<KeyValuePair<Item, int>> kvpList = new List<KeyValuePair<Item, int>>();
            kvpList.Add(new KeyValuePair<Item, int>(objItemC, 1));
            kvpList.Add(new KeyValuePair<Item, int>(objItemD, 1));

            IPromotionRule objRuleA = new BuyNQtyAtFixedPrice("Promotion A", 130, 3, "A");
            IPromotionRule objRuleB = new BuyNQtyAtFixedPrice("Promotion B", 45, 2, "B");
            IPromotionRule objRuleC = new BuyNItemsAtFixedPrice("Combination C & D", 30, kvpList);

            //Creating instance of RuleEngine
            IPromotion objPromotion = new PromotionEngine();

            objPromotion.ApplyPromotion(objRuleA, objKart);
            objPromotion.ApplyPromotion(objRuleB, objKart);
            objPromotion.ApplyPromotion(objRuleC, objKart);

            Assert.AreEqual(280, objKart.CalculateAmountPayable());


        }
    }
}
