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

        public string ExecuteCommand(Player p, string input)
        {
            string[] parts = input.Split(' ');
            string verb = parts[0];
            string[] args = parts.Skip(1).ToArray();

            foreach (Command command in _commands)
            {
                if (command.AreYou(verb))
                {
                    return command.Execute(p, args);
                }
            }

            return "I don't know how to do that.";
        }
    }
}