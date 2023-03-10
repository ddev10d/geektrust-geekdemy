using System;
using System.Collections.Generic;
using System.Threading;

namespace GeekTrust
{
    internal class ApplyCouponService : IOperationService
    {
        internal static ApplyCouponService GetInstance()
        {
            return new ApplyCouponService();
            throw new NotImplementedException();
        }

        public string processOperation(List<string> operands, ShoppingCart cart)
        {
            string couponType = "";
            if (cart.programmes.Count >= 4)
            {
                couponType = "B4G1";
                return cart.AddCoupon(couponType);
            }
            couponType = operands[0];
            return cart.AddCoupon(couponType);           
            throw new NotImplementedException();
        }
    }
}