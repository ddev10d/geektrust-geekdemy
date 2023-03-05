using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTrust
{
    public interface IOperationService
    {
        public string processOperation(List<string> operands, ShoppingCart cart);
    }
}
