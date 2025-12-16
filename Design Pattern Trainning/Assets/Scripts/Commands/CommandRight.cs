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
            PlayerCore.instance.AnimationPlayer.UpdatePlayerSprite(Direction.Right);
        }

        public void Undo()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Left);
            PlayerCore.instance.AnimationPlayer.UpdatePlayerSprite(Direction.Left);
        }
    }
}