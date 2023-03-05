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
        internal decimal CalculateSubtotal(decimal discountedCost)
        {   
            decimal subtotalWithoutProMembershipFees = CalculateTotalCost(discountedCost);
            return cart.IsProMember ? subtotalWithoutProMembershipFees + 200 : subtotalWithoutProMembershipFees;
            throw new NotImplementedException();
        }
        internal decimal CalculateCouponDiscount(decimal subTotal)
        {   
            if(cart.programmes.Count >= 4)
            {
                 cart.appliedCoupon = new B41G();
                 return ShoppingCart.GetCostOfCheapestProgramme(cart.programmes);
            }
            if(cart.appliedCoupon is DealG20 && subTotal >= 10000)
            {
                return subTotal * 0.20m;
            }
            if(cart.appliedCoupon is DealG5 && cart.programmes.Count >= 2)
            {
                return subTotal * 0.05m;
            }
            return 0;
            throw new NotImplementedException();
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
            decimal SubTotal = CalculateSubtotal(ProMembershipDiscount);
            decimal couponDiscount = CalculateCouponDiscount(SubTotal);
            decimal enrollmentFees = CalculateEnrollmentFees(SubTotal-couponDiscount);
            decimal grandTotal = SubTotal - couponDiscount + enrollmentFees;

            Console.WriteLine("SUB_TOTAL {0:0.00}", SubTotal);
            Console.WriteLine("COUPON_DISCOUNT {0} {1:0.00}", cart.appliedCoupon?.Code.ToString(), couponDiscount);
            Console.WriteLine("TOTAL_PRO_DISCOUNT {0:0.00}", ProMembershipDiscount);
            Console.WriteLine("PRO_MEMBERSHIP_FEE {0:0.00}", getProMembershipFee());
            Console.WriteLine("ENROLLMENT_FEE {0:0.00}", enrollmentFees);
            Console.WriteLine("TOTAL {0:0.00}", grandTotal);

            return "";
        }
    }
}
