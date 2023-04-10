

using System.Linq;

namespace GeekTrust.Models
{
    public abstract class Coupon
    {
        public string Code { get; set; }
       
        public decimal? DiscountPercentage { get; set; }
        public decimal discountAmount { get; }
        protected const decimal DEALG20_DISCOUNT_PERCENTAGE = 0.2m;
        protected const decimal DEALG5_DISCOUNT_PERCENTAGE = 0.05m;

        protected Coupon(string code, decimal? discountPercentage)
        {
            Code = code;
            DiscountPercentage = discountPercentage;
        }
        public abstract bool IsCouponApplicable(ShoppingCart cart);
        public abstract decimal getDiscountAmount(ShoppingCart cart);
    }

    public class DealG20 : Coupon
    {
        public DealG20() : base("DEAL_G20", DEALG20_DISCOUNT_PERCENTAGE) { }

        public override decimal getDiscountAmount(ShoppingCart cart)
        {
            return (decimal)(cart.GetSubtotal() * DiscountPercentage);
            throw new System.NotImplementedException();
        }

        public override bool IsCouponApplicable(ShoppingCart cart)
        {
            return cart.GetSubtotal() >= 10000;
            throw new System.NotImplementedException();
        }
    }
    public class DealG5 : Coupon
    {
        public DealG5() : base("DEAL_G5", DEALG5_DISCOUNT_PERCENTAGE) { }

        public override decimal getDiscountAmount(ShoppingCart cart)
        {
            return (decimal)(cart.GetSubtotal() * DiscountPercentage);
            throw new System.NotImplementedException();
        }

        public override bool IsCouponApplicable(ShoppingCart cart)
        {
            return cart.programmes.Count >= 2;
            throw new System.NotImplementedException();
        }
    }
    public class B41G : Coupon
    {
        public B41G() : base("B4G1", null) { }

        public override decimal getDiscountAmount(ShoppingCart cart)
        {
            Programme programme = cart.programmes.OrderBy(o => o.Cost).First();
            if (cart.IsProMember)
            {
                return programme.Cost * (1-programme.ProMemberShipDiscount);
            }
            return programme.Cost; 
            throw new System.NotImplementedException();
        }

        public override bool IsCouponApplicable(ShoppingCart cart)
        {
            return cart.programmes.Count >= 4;
            throw new System.NotImplementedException();
        }
    }
}
