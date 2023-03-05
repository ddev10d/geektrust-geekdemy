using System;
using System.Collections.Generic;

namespace GeekTrust
{
    internal class AddProgrammeService : IOperationService
    {
        internal static AddProgrammeService GetInstance()
        {
            return new AddProgrammeService();
            throw new NotImplementedException();
        }

        public string processOperation(List<string> operands, ShoppingCart cart)
        {
            string programmeCateogry = operands[0];
            int numberOfProgrammes = Convert.ToInt32(operands[1]);
            return cart.AddProgrammes(programmeCateogry, numberOfProgrammes);
            throw new NotImplementedException();
        }
    }
}