using System;
using System.IO;
using System.Collections.Generic;

namespace GeekTrust
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("here1");
                string[] commands = File.ReadAllLines(args[0]);
                Console.WriteLine("here2");
                List<string> operands = new List<string>();
                List<string> operators = new List<string>();
                foreach (string command in commands)
                {
                    if(command.Split(" ")[0] == "PRINT_BILL")
                    {
                        continue;
                    }
                    operands.Add(command.Split(" ")[0]);
                    operators.Add(command.Split(" ")[1]);
                }
                foreach (string operand in operands)
                {
                    Console.WriteLine(operand);
                }
                foreach (string operato in operators)
                {
                    Console.WriteLine(operato);
                }
                //Add your code here to process the input commands

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}