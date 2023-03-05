using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeekTrust
{
    internal class ReadFromFile
    {
        private string _filePath;
        public ReadFromFile(string filepath)
        {
             _filePath=filepath;
        }

        public List<Command> commandList()
        {
            List<string> commands = File.ReadAllLines(_filePath)
                                        .ToList<string>();

            return commands.Where(str => !string.IsNullOrEmpty(str))
                           .Select(str => Command.From(str))
                           .ToList();
        }
    }
}
