using System;
using System.Collections.Generic;

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
            string couponType = operands[0];
            return cart.AddCoupon(couponType);           
            throw new NotImplementedException();
        }
    }
}