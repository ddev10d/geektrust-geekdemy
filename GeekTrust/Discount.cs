using GeekTrust.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace GeekTrust
{
    public abstract class Discount
    {
        decimal discountAmount;
        protected ShoppingCart cart;
        public Discount(ShoppingCart cart)
        {
            this.cart = cart;
        }
        public abstract decimal DiscountCalculation();
    }

    public class ProMembershipDiscount : Discount
    {
        public ProMembershipDiscount(ShoppingCart cart) : base(cart)
        {
        }

        public override decimal DiscountCalculation()
        {
            decimal totalProDiscount = 0;
            if (cart.IsProMember)
            {
                foreach (Programme programme in cart.programmes)
                {
                    totalProDiscount += programme.Cost * programme.ProMemberShipDiscount;
                }
            }
            return totalProDiscount;
            throw new NotImplementedException();
        }
    }

    public class CouponDiscount : Discount
    {
        public CouponDiscount(ShoppingCart cart) : base(cart)
        {
        }

        public override decimal DiscountCalculation()
        {
            List<decimal> discountAmounts = new List<decimal>();
            if (cart.appliedCoupons.Count < 1)
            {
                Coupon coupon = new B41G();
                coupon.IsCouponApplicable(cart);
                return coupon.getDiscountAmount(cart);
            }
            foreach (Coupon coupon in cart.appliedCoupons)
            {
                if (coupon.IsCouponApplicable(cart))
                {
                    discountAmounts.Add(coupon.getDiscountAmount(cart));
                }
            }

            discountAmounts.Sort();
            if (discountAmounts.Count < 1)
            {
                return 0.0m;
            }
            return discountAmounts.Last();
            throw new NotImplementedException();
        }
    }
}
