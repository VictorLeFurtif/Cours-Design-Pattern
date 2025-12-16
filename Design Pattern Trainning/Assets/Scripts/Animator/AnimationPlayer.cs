using System;
using Enum;
using UnityEngine;

namespace Animator
{
    public class AnimationPlayer : MonoBehaviour
    {
        [SerializeField] private Sprite[] everyDirectionSprite;

        [SerializeField] private SpriteRenderer spriteRendererPlayer;

        public void UpdatePlayerSprite(Direction _direction)
        {
            switch (_direction)
            {
                case Direction.Front:
                    UpdateSprite(spriteRendererPlayer,everyDirectionSprite[0]);
                    break;
                case Direction.Back:
                    UpdateSprite(spriteRendererPlayer,everyDirectionSprite[1]);
                    break;
                case Direction.Left:
                    UpdateSprite(spriteRendererPlayer,everyDirectionSprite[2]);
                    break;
                case Direction.Right:
                    UpdateSprite(spriteRendererPlayer,everyDirectionSprite[3]);
                    break;
                case Direction.Null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_direction), _direction, null);
            }
        }

        private void UpdateSprite(SpriteRenderer _sprite, Sprite _spriteToApply)
        {
            _sprite.sprite = _spriteToApply;
        }
    }
}