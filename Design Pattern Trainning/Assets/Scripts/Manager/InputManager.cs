using System;
using System.Collections.Generic;
using Commands;
using Enum;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private CommandInvoker commandInvoker;

        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private float rayDistance = 1f;

        private static readonly Dictionary<Direction, Vector2> directionMap = new()
        {
            { Direction.Front, Vector2.up },
            { Direction.Back, Vector2.down },
            { Direction.Left, Vector2.left },
            { Direction.Right, Vector2.right }
        };

        private void Awake()
        {
            commandInvoker = new CommandInvoker();
        }

        public void OnMove(InputValue inputValue)
        {
            Vector2 v = inputValue.Get<Vector2>();
            Direction direction = DirectionDepedencies.GetDirectionByVectorInput(v);

            if (direction == Direction.Null)
                return;

            if (!CanMoveInDirectionChosen(direction))
                return;

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
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public void OnUndo()
        {
            commandInvoker.UndoCommand();
        }

        private bool CanMoveInDirectionChosen(Direction direction)
        {
            if (!directionMap.TryGetValue(direction, out Vector2 dir))
                return false;

            return !Physics2D.Raycast(
                transform.position,
                dir,
                rayDistance,
                wallLayer
            );
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            foreach (var pair in directionMap)
            {
                Gizmos.DrawLine(
                    transform.position,
                    transform.position + (Vector3)(pair.Value * rayDistance)
                );
            }
        }
#endif
    }
}
