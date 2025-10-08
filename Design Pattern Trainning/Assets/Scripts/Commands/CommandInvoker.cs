using System.Collections.Generic;
using Interface;

namespace Commands
{
    public class CommandInvoker
    {
        private Stack<ICommand> commandStack = new Stack<ICommand>();

        public void DoCommand(ICommand _command)
        {
            _command.Execute();
            commandStack.Push(_command);
        }

        public void UndoCommand()
        {
            if (commandStack.Count > 0)
            {
                commandStack.Pop().Undo();
            }
        }

        
    }
}