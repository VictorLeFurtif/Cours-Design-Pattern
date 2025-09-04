using System;
using Commands;
using Enum;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private CommandInvoker commandInvoker;

        private void Awake()
        {
            commandInvoker = new CommandInvoker();
        }

        public void OnMove(InputValue inputValue)
        {
            var v = inputValue.Get<Vector2>();
            Direction direction = DirectionDepedencies.GetDirectionByVectorInput(v);
            
            
            switch (direction)
            {
                case Direction.Front:
                    commandInvoker.DoCommand(new CommandFront());
                    break;
                case Direction.Back:
                    commandInvoker.DoCommand(new CommandBack());
                    break;
                case Direction.Left:
                    commandInvoker.DoCommand(new CommandLeft());
                    break;
                case Direction.Right:
                    commandInvoker.DoCommand(new CommandRight());
                    break;
                case Direction.Null : break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public void OnUndo()
        {
            commandInvoker.UndoCommand();
        }
    }
}