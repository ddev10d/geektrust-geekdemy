

using System.Linq;

namespace GeekTrust.Models
{
    public abstract class Coupon
    {
        public string Code { get; set; }
       
        public decimal? DiscountPercentage { get; set; }
        public decimal discountAmount { get; }
        
        protected Coupon(string code, decimal? discountPercentage)
        {
            Code = code;
            DiscountPercentage = discountPercentage;
        }
        public abstract bool IsCouponApplicable(ShoppingCart cart, decimal Subtotal);
        public abstract decimal getDiscountAmount(ShoppingCart cart, decimal Subtotal);
    }

    public class DealG20 : Coupon
    {
        public DealG20() : base("DEAL_G20", 0.2m) { }

        public override decimal getDiscountAmount(ShoppingCart cart, decimal Subtotal)
        {
            return (decimal)(Subtotal * DiscountPercentage);
            throw new System.NotImplementedException();
        }

        public override bool IsCouponApplicable(ShoppingCart cart, decimal Subtotal)
        {
            return Subtotal >= 10000;
            throw new System.NotImplementedException();
        }
    }
    public class DealG5 : Coupon
    {
        public DealG5() : base("DEAL_G5", 0.1m) { }

        public override decimal getDiscountAmount(ShoppingCart cart, decimal Subtotal)
        {
            return (decimal)(Subtotal * DiscountPercentage);
            throw new System.NotImplementedException();
        }

        public override bool IsCouponApplicable(ShoppingCart cart, decimal Subtotal)
        {
            return cart.programmes.Count >= 2;
            throw new System.NotImplementedException();
        }
    }
    public class B41G : Coupon
    {
        public B41G() : base("B4G1", null) { }

        public override decimal getDiscountAmount(ShoppingCart cart, decimal Subtotal)
        {
            Programme programme = cart.programmes.OrderBy(o => o.Cost).First();
            if (cart.IsProMember)
            {
                return programme.Cost * programme.ProMemberShipDiscount;
            }
            return programme.Cost; 
            throw new System.NotImplementedException();
        }

        public override bool IsCouponApplicable(ShoppingCart cart, decimal Subtotal)
        {
            return cart.programmes.Count >= 4;
            throw new System.NotImplementedException();
        }
    }
}
