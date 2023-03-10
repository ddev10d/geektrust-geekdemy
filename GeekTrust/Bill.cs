using GeekTrust;
using GeekTrust.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekTrust
{
    public class Bill
    {
        private readonly ShoppingCart cart;
        
        public Bill(ShoppingCart cart)
        {
            this.cart = cart;
        }
        public decimal CalculateTotalProDiscount()
        {
            decimal totalProDiscount = 0;
            if (cart.IsProMember)
            {
                foreach(Programme programme in cart.programmes)
                {
                    totalProDiscount += programme.Cost * programme.ProMemberShipDiscount;
                }
            }
            return totalProDiscount;
        }
        public decimal CalculateTotalCost(decimal discount)
        {
            decimal totalCost = 0;
            foreach (Programme item in cart.programmes)
            {
               
                totalCost += item.Cost;
            }
            totalCost -= discount;
            return totalCost;
        }
        internal ShoppingCart CalculateSubtotal(decimal discountedCost)
        {   
            decimal subtotalWithoutProMembershipFees = CalculateTotalCost(discountedCost);
            decimal subtotalWithProMemberShip = subtotalWithoutProMembershipFees + cart.ProMemberShipFees();
            cart.SetSubTotal(subtotalWithProMemberShip); 
            return cart;
            throw new NotImplementedException();
        }
        internal decimal ApplyCouponDiscount(ShoppingCart cart)
        {
            //if(cart.programmes.Count >= 4)
            //{
            //     cart.appliedCoupon = new B41G();
            //     return ShoppingCart.GetCostOfCheapestProgramme(cart.programmes);
            //}
            //if(cart.appliedCoupon is DealG20 && subTotal >= 10000)
            //{
            //    return subTotal * 0.20m;
            //}
            //if(cart.appliedCoupon is DealG5 && cart.programmes.Count >= 2)
            //{
            //    return subTotal * 0.05m;
            //}

            decimal couponDiscount = GetBestValueCoupon(cart);
            return couponDiscount;
            throw new NotImplementedException();
        }
        public decimal GetBestValueCoupon(ShoppingCart cart)
        {
            List<decimal> discountAmounts = new List<decimal>();
            if(cart.appliedCoupons.Count < 1)
            {
                Coupon coupon = new B41G();
                coupon.IsCouponApplicable(cart);
                return coupon.getDiscountAmount(cart);
            }
            foreach(Coupon coupon in cart.appliedCoupons)
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
        }
        public decimal getProMembershipFee()
        {
            if (cart.IsProMember)
            {
                return 200;
            }
            return 0;
        }
        public decimal CalculateEnrollmentFees(decimal cost)
        {
            if(cost < 6666)
            {
                return 500;
            }
            return 0;
        }
        public string generateBill()
        {
            decimal ProMembershipDiscount = CalculateTotalProDiscount();
            //Discount promembershipdiscount = new ProMembershipDiscount(cart);
            //decimal ProMembershipdiscountamount = promembershipdiscount.DiscountCalculation();
            CalculateSubtotal(ProMembershipDiscount);
            decimal couponDiscount = ApplyCouponDiscount(cart);
            decimal enrollmentFees = CalculateEnrollmentFees(cart.GetSubtotal()-couponDiscount);
            decimal grandTotal = cart.GetSubtotal()- couponDiscount + enrollmentFees;
            string couponName = couponDiscount == 0 ? "NONE" : cart.appliedCoupons.First().Code;



            Console.WriteLine("SUB_TOTAL {0:0.00}", cart.GetSubtotal());
            Console.WriteLine("COUPON_DISCOUNT {0} {1:0.00}", couponName , couponDiscount);
            Console.WriteLine("TOTAL_PRO_DISCOUNT {0:0.00}", ProMembershipDiscount);
            Console.WriteLine("PRO_MEMBERSHIP_FEE {0:0.00}", getProMembershipFee());
            Console.WriteLine("ENROLLMENT_FEE {0:0.00}", enrollmentFees);
            Console.WriteLine("TOTAL {0:0.00}", grandTotal);

            return "";
        }
    }
}

/* CalculateCouponDiscount: ShoppingCart, Coupon => couponDiscount
    step - 1 get the applied coupon on the cart
    step-2 Calculate coupon discount as per rules
 coupon is calculated on the subtotal of the cart, in that case it's not necessary to pass the whole ShoppingCart
 object to the coupon. 


 Higher Valued Coupon: (ShoppingCart, List<Coupon>) => Coupon

regarding the input of coupons on the shopping cart, multiple coupons can be applied, we need to store each of the
applied coupons in a list, since we can't decide beforehand which one is high value.






*/