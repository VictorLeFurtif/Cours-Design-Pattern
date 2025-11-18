using Enum;
using Interface;
using Player;

namespace Commands
{
    public class CommandBack : ICommand
    {
        public void Execute()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Back);
            PlayerCore.instance.AnimationPlayer.UpdatePlayerSprite(Direction.Back);
        }

        public void Undo()
        {
            PlayerCore.instance.playerController.MovePlayer(Direction.Front);
            PlayerCore.instance.AnimationPlayer.UpdatePlayerSprite(Direction.Front);
        }
    }
}