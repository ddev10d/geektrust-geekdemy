using System;
using System.Collections.Generic;

namespace GeekTrust
{
    internal class AddProMembershipService : IOperationService
    {
        internal static AddProMembershipService GetInstance()
        {
            return new AddProMembershipService();
            throw new NotImplementedException();
        }

        public string processOperation(List<string> operands, ShoppingCart cart)
        {
            return cart.AddProMembership();
            throw new NotImplementedException();
        }
    }
}