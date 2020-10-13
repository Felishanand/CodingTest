using System;
using System.Collections.Generic;
using System.Text;

namespace CodingTest
{
    class PromotionResult : IPromotionResult
    {
        public Boolean PromotionApplied { get; set; }
        public bool IsPromotionApplied()
        {
            return PromotionApplied;
        }
    }
}
