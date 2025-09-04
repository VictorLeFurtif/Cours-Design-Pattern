using Controller;
using Enum;
using Interface;

namespace Commands
{
    public class CommandLeft : ICommand
    {
        public void Execute()
        {
            PlayerController.instance.MovePlayer(Direction.Left);
        }

        public void Undo()
        {
            PlayerController.instance.MovePlayer(Direction.Right);
        }
    }
}