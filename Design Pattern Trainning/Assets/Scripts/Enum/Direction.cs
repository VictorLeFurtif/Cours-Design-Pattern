using System.Numerics;
using Vector2 = UnityEngine.Vector2;

namespace Enum
{
    public enum Direction
    {
        Front,
        Back,
        Left,
        Right,
        Null
    }

    public static class DirectionDepedencies
    {
        public static Direction GetDirectionByVectorInput(Vector2 _vector)
        {
            Direction result = Direction.Null;
            
            
            if (_vector.x > 0.9)
            {
                result = Direction.Right;
            }

            else if (_vector.x < -0.9)
            {
                result = Direction.Left;
            }
            
            else if (_vector.y > 0.9)
            {
                
                result = Direction.Front;
            }
            
            else if (_vector.y < -0.9)
            {
                
                result = Direction.Back;
            }

            return result;
        }
    }
}