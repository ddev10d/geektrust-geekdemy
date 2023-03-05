using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;

namespace GeekTrust
{
    public class Command
    {
        public Operator _operator { get; set; }
        public List<string> operands { get; set; }  
        public Command(Operator @operator, List<string> operands)
        {
            _operator = @operator;
            this.operands = operands;
        }
        public static Command From(string line)
        {
            List<string> commandsWithArguments = line.Trim().Split(" ").ToList<string>();
            Operator _operator = Operator.FromDisplayName<Operator>(commandsWithArguments[0]);
            List<string> operands = commandsWithArguments.Skip(1).ToList<string>();
            if (_operator.Value < operands.Count)
            {
                throw new Exception("operand count invalid");
            }
            Command command = new Command(_operator, operands);
            return command;
        }
    }
}
