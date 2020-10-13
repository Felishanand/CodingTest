using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest.Models
{
    public class Item
    {
        private int itemId;
        private double itemPrice;
        private string itemName;
        private string description;

        public int ItemId { get => itemId; set => itemId = value; }
        public double ItemPrice { get => itemPrice; set => itemPrice = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public string Description { get => description; set => description = value; }
    }




}
