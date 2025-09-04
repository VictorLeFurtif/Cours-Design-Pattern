using Controller;
using Enum;
using Interface;

namespace Commands
{
    public class CommandRight : ICommand
    {
        public void Execute()
        {
            PlayerController.instance.MovePlayer(Direction.Right);
        }

        public void Undo()
        {
            PlayerController.instance.MovePlayer(Direction.Left);
        }
    }
}