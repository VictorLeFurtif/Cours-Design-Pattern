using Enum;
using Interface;
using Player;

namespace Commands
{
    public class CommandRight : ICommand
    {
        public void Execute()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Right);
        }

        public void Undo()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Left);
        }
    }
}