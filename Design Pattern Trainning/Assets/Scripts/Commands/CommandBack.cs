using Controller;
using Enum;
using Interface;

namespace Commands
{
    public class CommandBack : ICommand
    {
        public void Execute()
        {
            PlayerController.instance.MovePlayer(Direction.Back);
        }

        public void Undo()
        {
            PlayerController.instance.MovePlayer(Direction.Front);
        }
    }
}