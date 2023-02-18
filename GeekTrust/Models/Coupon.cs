using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust.Models
{
    public class Coupon
    {
        public string Code { get; set; }
        public float DiscountPercentage { get; set; }

        protected Coupon(string code, float discountPercentage)
        {
            Code = code;
            DiscountPercentage = discountPercentage;
        }
    }

    public class DealG20 : Coupon
    {
        public DealG20() : base("DEAL_G20", 0.2f) { }
    }
    public class DealG5 : Coupon
    {
        public DealG5() : base("DEAL_G5", 0.1f) { }
    }
}
