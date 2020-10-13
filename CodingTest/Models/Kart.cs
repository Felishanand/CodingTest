using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.Models
{
    public class Kart : IItemList
    {
        private readonly List<KartItem> _KartItemList;

        public Kart(List<KartItem> objList)
        {
            _KartItemList = objList;
        }

        public double CalculateAmountPayable()
        {
            return _KartItemList.Sum(o => o.AmountPayable);
        }

        public List<KartItem> GetItemList()
        {
            return _KartItemList;
        }
    }
}
