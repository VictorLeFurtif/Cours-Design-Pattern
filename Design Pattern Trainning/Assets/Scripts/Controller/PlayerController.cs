using System;
using Enum;
using UnityEngine;

namespace Controller
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private int movingDistance;

        public static PlayerController instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }


        public void MovePlayer(Direction _direction)
        {
            switch (_direction)
            {
                case Direction.Front:
                    transform.position = new Vector2(transform.position.x + movingDistance, transform.position.y); 
                    break;
                case Direction.Back:
                    transform.position = new Vector2(transform.position.x - movingDistance, transform.position.y); 
                    break;
                case Direction.Left:
                    transform.position = new Vector2(transform.position.x, transform.position.y - movingDistance); 
                    break;
                case Direction.Right:
                    transform.position = new Vector2(transform.position.x, transform.position.y + movingDistance); 
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_direction), _direction, null);
            }
        }
    }
}
