using System;
using System.Collections.Generic;

namespace GeekTrust
{
    internal class PrintBillService : IOperationService
    {
        internal static PrintBillService GetInstance()
        {
            return new PrintBillService();
            throw new NotImplementedException();
        }

        public string processOperation(List<string> operands, ShoppingCart cart)
        {
            return cart.printBill(cart);
            throw new NotImplementedException();
        }
    }
}