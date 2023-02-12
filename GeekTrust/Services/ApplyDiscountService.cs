using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust.Services
{
    internal class ApplyDiscountService
    {
        private string _discountName;
        private float discountAmount;
        public ApplyDiscountService(ShoppingCart shoppingCart)
        {
            GetDiscountAmount(shoppingCart);
        }

        public float GetDiscountAmount(ShoppingCart shoppingCart)
        {
            if (shoppingCart.GetProMembershipStatus())
            {
                foreach(var programme in shoppingCart._programmes)
                {

                }
            }
        }
    }
}
