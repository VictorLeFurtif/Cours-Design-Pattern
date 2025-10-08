using Enum;
using Interface;
using Player;

namespace Commands
{
    public class CommandFront : ICommand
    {
        public void Execute()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Front);
        }

        public void Undo()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Back);
        }
    }
}