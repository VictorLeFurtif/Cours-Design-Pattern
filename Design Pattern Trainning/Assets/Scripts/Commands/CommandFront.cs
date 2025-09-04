using Controller;
using Enum;
using Interface;

namespace Commands
{
    public class CommandFront : ICommand
    {
        public void Execute()
        {
            PlayerController.instance.MovePlayer(Direction.Front);
        }

        public void Undo()
        {
            PlayerController.instance.MovePlayer(Direction.Back);
        }
    }
}