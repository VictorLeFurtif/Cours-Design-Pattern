using Enum;
using Interface;
using Player;

namespace Commands
{
    public class CommandLeft : ICommand
    {
        public void Execute()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Left);
        }

        public void Undo()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Right);
        }
    }
}