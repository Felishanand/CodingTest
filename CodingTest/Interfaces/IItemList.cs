using CodingTest.Models;
using System.Collections.Generic;


namespace CodingTest
{
    public interface IItemList
    {
        public List<KartItem> GetItemList();

        public void AddKartItem(KartItem item);
    }
}