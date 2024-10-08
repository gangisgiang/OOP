using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public string ExecuteCommand(Player p, string commandString)
        {
            string[] parts = commandString.Split(' ');

            foreach (Command command in _commands)
            {
                if (command.AreYou(parts[0]))
                {
                    return command.Execute(p, parts);
                }
            }

            return "I don't know how to " + parts[0] + " like that.";
        }
    }
}