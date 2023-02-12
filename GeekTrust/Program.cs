using System;
using System.IO;
using System.Collections.Generic;

namespace GeekTrust
{
    public class Programmes
    {

    }
    
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] commands = File.ReadAllLines(args[0]);
                ShoppingCart shoppingCart = new ShoppingCart();
                foreach(string command in commands)
                {
                    if(command.Split(" ")[0] == "ADD_PROGRAMME")
                    {
                        shoppingCart.AddProgramme(command.Split(" ")[1], Convert.ToInt32(command.Split(" ")[2]));
                    }
                    if(command.Split(" ")[0] == "APPLY_COUPON")
                    {
                        shoppingCart.ApplyCoupon(command.Split(" ")[1]);
                    }
                    if(command.Split(" ")[0] == "ADD_PRO_MEMBERSHIP")
                    {
                        shoppingCart.AddProMembership();
                    }

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