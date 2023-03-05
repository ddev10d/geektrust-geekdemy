using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeekTrust
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = args[0];
                ReadFromFile readFromFile = new ReadFromFile(filePath);
                ShoppingCart cart = new ShoppingCart();
                List<Command> inputData = readFromFile.commandList();
                //Add your code here to process the input commands
                List<String> outputs = inputData.Select(command => command
                                                                    ._operator
                                                                    ._operationService
                                                                    .processOperation(command.operands, cart))
                                                                    .ToList();
                //foreach(string output in outputs)
                //{
                //    Console.WriteLine(output);
                //}
                //Console.WriteLine(inputData[0].operator);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }


        }
    }
}
